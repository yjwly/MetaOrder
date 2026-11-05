using SystemService.Infra.Entities;

namespace SystemService.Infra.Repositories.Interface.User
{
    /// <summary>
    /// 角色权限关联仓储接口
    /// </summary>
    public interface ISysRolePermissionRepository
    {
        /// <summary>
        /// 根据角色ID查菜单ID列表
        /// </summary>
        Task<List<long>> GetMenuIdsByRoleIdAsync(long roleId);

        /// <summary>
        /// 根据角色ID查按钮ID列表
        /// </summary>
        Task<List<long>> GetButtonIdsByRoleIdAsync(long roleId);

        /// <summary>
        /// 根据角色ID删除所有权限
        /// </summary>
        Task DeleteByRoleIdAsync(long roleId);

        /// <summary>
        /// 批量添加
        /// </summary>
        Task AddRangeAsync(List<SysRolePermission> list);
    }
}
