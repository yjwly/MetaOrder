using SystemService.Infra.Entities;

namespace SystemService.Infra.Repositories.Interface.Menu
{
    /// <summary>
    /// 角色菜单关联仓储接口
    /// </summary>
    public interface ISysRoleMenuRepository
    {
        /// <summary>
        /// 根据角色ID查菜单ID列表
        /// </summary>
        Task<List<long>> GetMenuIdsByRoleIdAsync(long roleId);

        /// <summary>
        /// 根据角色ID删除所有菜单
        /// </summary>
        Task DeleteByRoleIdAsync(long roleId);

        /// <summary>
        /// 批量添加
        /// </summary>
        Task AddRangeAsync(List<SysRoleMenu> list);
    }
}
