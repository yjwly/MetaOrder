using AuthService.Infra.Dtos;
using AuthService.Infra.Entities;
using AuthService.Infra.Repositories.@interface;
using AuthService.Service.Interface;
using Dm.filter;
using Microsoft.IdentityModel.Tokens;
using Polly;
using Shared.Db.Base;
using SharedKernel.Helper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Service.Serv
{
    public class AuthAppService:IAuthAppService
    {
        private readonly ISysUserRepository _userRepo;
        private readonly IConfiguration _config;
        private readonly IRedisService _redis;

        public AuthAppService(ISysUserRepository userRepo, IConfiguration config, IRedisService redis)
        {
            _userRepo = userRepo;
            _config = config;
            _redis = redis;
        }
        /// <summary>登录</summary>
        public async Task<(string accessToken, string refreshToken)> LoginAsync(LoginDto dto)
        {
            // 1. 查用户
            var user = await _userRepo.GetByUserNameAsync(dto.UserName);
            if (user == null)
                throw new Exception("用户不存在");

            // 2. 验证密码
            var passwordHash = EncryptionHelper.MD5(dto.Password + user.Id.ToString());
            if (passwordHash != user.PasswordHash)
                throw new Exception("密码错误");

            // 3. 检查状态
            if (user.Status != 1)
                throw new Exception("账号已禁用");

            // 4. 生成Access Token
            var accessToken = GenerateAccessToken(user);

            // 5. 生成Refresh Token，存Redis（key里加设备类型）
            var refreshToken = Guid.NewGuid().ToString("N");
            await _redis.SetAsync(
                $"refresh_token:{dto.DeviceType}:{refreshToken}",
                user.Id.ToString(),
                TimeSpan.FromDays(7));

            // 6. 更新最后登录时间
            user.LastLoginTime = DateTime.Now;
            await _userRepo.UpdateAsync(user);

            return (accessToken, refreshToken);
        }

        /// <summary>刷新Token</summary>
        public async Task<(string accessToken, string refreshToken)> RefreshAsync(string deviceType, string refreshToken)
        {
            // 1. 从Redis查刷新令牌
            var userIdStr = await _redis.GetAsync($"refresh_token:{deviceType}:{refreshToken}");
            if (string.IsNullOrEmpty(userIdStr))
                throw new Exception("刷新令牌已过期或无效");

            var userId = long.Parse(userIdStr);

            // 2. 查用户
            var user = await _userRepo.GetByIdAsync(userId);
            if (user == null || user.Status != 1)
                throw new Exception("用户不存在或已禁用");

            // 3. 删除旧的刷新令牌
            await _redis.RemoveAsync($"refresh_token:{deviceType}:{refreshToken}");

            // 4. 生成新的Access Token
            var accessToken = GenerateAccessToken(user);

            // 5. 生成新的Refresh Token
            var newRefreshToken = Guid.NewGuid().ToString("N");
            await _redis.SetAsync(
                $"refresh_token:{deviceType}:{newRefreshToken}",
                user.Id.ToString(),
                TimeSpan.FromDays(7));

            return (accessToken, newRefreshToken);
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <summary>
        public async Task LogoutAsync(string deviceType, string refreshToken)
        {
            await _redis.RemoveAsync($"refresh_token:{deviceType}:{refreshToken}");
        }

        /// <summary>
        /// 生成Access Token（2小时）
        /// </summary>
        private string GenerateAccessToken(Infra.Entities.SysUser user)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Auth:SecretKey"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim("tenant_id", user.TenantId.ToString()),
            new Claim("company_id", user.CompanyId.ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _config["Auth:Issuer"],
                audience: _config["Auth:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
