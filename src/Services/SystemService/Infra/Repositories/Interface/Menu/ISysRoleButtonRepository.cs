using SystemService.Infra.Entities;

namespace SystemService.Infra.Repositories.Interface.Menu
{
    /// <summary>
    /// 角色按钮关联仓储接口
    /// </summary>
    public interface ISysRoleButtonRepository
    {
        /// <summary>
        /// 根据角色ID查按钮ID列表
        /// </summary>
        Task<List<long>> GetButtonIdsByRoleIdAsync(long roleId);

        /// <summary>
        /// 根据角色ID删除所有按钮
        /// </summary>
        Task DeleteByRoleIdAsync(long roleId);

        /// <summary>
        /// 批量添加
        /// </summary>
        Task AddRangeAsync(List<SysRoleButton> list);
    }
}
