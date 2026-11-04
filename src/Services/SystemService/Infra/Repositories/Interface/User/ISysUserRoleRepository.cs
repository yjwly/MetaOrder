using Shared.Db.Base;
using SystemService.Infra.Entities;

namespace SystemService.Infra.Repositories.Interface
{
    public interface ISysUserRoleRepository 
    {
        /// <summary>
        /// 根据用户ID查角色ID列表
        /// </summary>
        Task<List<long>> GetRoleIdsByUserIdAsync(long userId);

        /// <summary>
        /// 根据用户ID删除所有角色
        /// </summary>
        Task DeleteByUserIdAsync(long userId);

        /// <summary>
        /// 批量添加
        /// </summary>
        Task AddRangeAsync(List<SysUserRole> list);
    }
}
