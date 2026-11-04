using SharedKernel;
using SystemService.Infra.Dtos.User;
using SystemService.Infra.Entities;
using SystemService.Infra.QueryDtos.User;

namespace SystemService.Service.Interface.User
{
    public interface IUserAppService
    {
        /// <summary>
        /// 获取用户列表
        /// </summary>
        Task<PagedResult<SysUser>> GetListAsync(UserQueryDto dto);

        /// <summary>
        /// 获取用户详情
        /// </summary>
        Task<SysUser> GetByIdAsync(long id);

        /// <summary>
        /// 添加用户
        /// </summary>
        Task<long> AddAsync(UserCreateDto dto);

        /// <summary>
        /// 修改用户
        /// </summary>
        Task UpdateAsync(long id, UserCreateDto dto);

        /// <summary>
        /// 删除用户
        /// </summary>
        Task DeleteAsync(long id);
    }
}
