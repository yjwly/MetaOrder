namespace SystemService.Service.Interface.User
{
    /// <summary>
    /// 角色权限关联服务接口
    /// </summary>
    public interface IRolePermissionAppService
    {
        /// <summary>
        /// 给角色分配菜单
        /// </summary>
        Task AssignMenusToRoleAsync(long roleId, List<long> menuIds);

        /// <summary>
        /// 给角色分配按钮
        /// </summary>
        Task AssignButtonsToRoleAsync(long roleId, List<long> buttonIds);

        /// <summary>
        /// 根据角色ID查菜单ID列表
        /// </summary>
        Task<List<long>> GetMenuIdsByRoleIdAsync(long roleId);

        /// <summary>
        /// 根据角色ID查按钮ID列表
        /// </summary>
        Task<List<long>> GetButtonIdsByRoleIdAsync(long roleId);
    }
}
