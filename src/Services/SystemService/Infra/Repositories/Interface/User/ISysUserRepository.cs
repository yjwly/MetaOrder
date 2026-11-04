using Shared.Db.Base;
using SystemService.Infra.Entities;
using SystemService.Infra.QueryDtos.User;

namespace SystemService.Infra.Repositories.Interface.User
{
    public interface ISysUserRepository : IBaseRepository<SysUser>
    {
        /// <summary>分页查询用户列表</summary>
        Task<List<SysUser>> GetPagedListAsync(UserQueryDto dto);

        /// <summary>总数</summary>
        Task<int> GetCountAsync(UserQueryDto dto);

        /// <summary>根据用户名查用户</summary>
        Task<SysUser?> GetByUserNameAsync(string userName);
    }
}
