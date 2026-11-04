using SharedKernel;
using SharedKernel.Helper;
using SqlSugar;
using SystemService.Infra.Dtos.User;
using SystemService.Infra.Entities;
using SystemService.Infra.QueryDtos.User;
using SystemService.Infra.Repositories.Interface.User;
using SystemService.Service.Interface.User;

namespace SystemService.Service.Serv.User
{
    public class UserAppService : IUserAppService
    {
        private readonly ISysUserRepository _userRepo;

        public UserAppService(ISysUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        public async Task<PagedResult<SysUser>> GetListAsync(UserQueryDto dto)
        {
            var list = await _userRepo.GetPagedListAsync(dto);
            var total = await _userRepo.GetCountAsync(dto);
            return new PagedResult<SysUser>
            {
                Items = list,
                Total = total,
                PageIndex = dto.PageIndex,
                PageSize = dto.PageSize
            };
        }
        /// <summary>
        /// 根据ID获取用户详情
        /// </summary>
        public async Task<SysUser?> GetByIdAsync(long id)
        {
            return await _userRepo.GetByIdAsync(id);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        public async Task<long> AddAsync(UserCreateDto dto)
        {
            var existUser = await _userRepo.GetByUserNameAsync(dto.UserName);
            if (existUser != null)
                throw new Exception("用户名已存在");

            var user = new SysUser
            {
                Id = SnowFlakeSingle.instance.getID(),
                UserName = dto.UserName,
                PasswordHash = EncryptionHelper.MD5(dto.Password + SnowFlakeSingle.instance.getID().ToString()),
                RealName = dto.RealName,
                Mobile = dto.Mobile,
                Email = dto.Email,
                Status = 1,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            };

            await _userRepo.AddAsync(user);
            return user.Id;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateAsync(long id, UserCreateDto dto)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
                throw new Exception("用户不存在");

            user.RealName = dto.RealName;
            user.Mobile = dto.Mobile;
            user.Email = dto.Email;
            user.Status = dto.Status;
            user.UpdatedTime = DateTime.Now;

          await _userRepo.UpdateAsync(user);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(long id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
                throw new Exception("用户不存在");

            user.IsDeleted = true;
            user.UpdatedTime = DateTime.Now;
            await _userRepo.UpdateAsync(user);
        }
    }
}
