namespace SystemService.Service.Interface.Menu
{
    /// <summary>
    /// 角色菜单关联服务接口
    /// </summary>
    public interface IRoleMenuAppService
    {
        /// <summary>
        /// 给角色分配菜单
        /// </summary>
        Task AssignMenusToRoleAsync(long roleId, List<long> menuIds);

        /// <summary>
        /// 根据角色ID查菜单ID列表
        /// </summary>
        Task<List<long>> GetMenuIdsByRoleIdAsync(long roleId);
    }
}
