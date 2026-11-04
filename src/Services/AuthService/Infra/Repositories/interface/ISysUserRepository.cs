using AuthService.Infra.Entities;
using Shared.Db.Base;

namespace AuthService.Infra.Repositories.@interface
{
    public interface ISysUserRepository : IBaseRepository<SysUser>
    {
        /// <summary>
        /// 根据用户名查用户
        /// </summary>
        Task<SysUser?> GetByUserNameAsync(string userName);
    }
}
