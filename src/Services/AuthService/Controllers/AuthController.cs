using AuthService.Infra.Dtos;
using AuthService.Service.Interface;
using AuthService.Service.Serv;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("api/auth/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthAppService _authApp;

        public AuthController(IAuthAppService authApp)
        {
            _authApp = authApp;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto">登录参数</param>
        /// <returns>Access Token + Refresh Token</returns>
        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var (accessToken, refreshToken) = await _authApp.LoginAsync(dto);
            return Ok(new { accessToken, refreshToken });
        }

        /// <summary>
        /// 刷新Token
        /// </summary>
        /// <param name="dto">刷新令牌参数</param>
        /// <returns>新的 Access Token + Refresh Token</returns>
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromQuery] string deviceType, [FromBody] RefreshTokenDto dto)
        {
            var (accessToken, refreshToken) = await _authApp.RefreshAsync(deviceType, dto.RefreshToken);
            return Ok(new { accessToken, refreshToken });
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="dto">刷新令牌参数</param>
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout([FromQuery] string deviceType, [FromBody] RefreshTokenDto dto)
        {
            await _authApp.LogoutAsync(deviceType,dto.RefreshToken);
            return Ok();
        }
    }
}
