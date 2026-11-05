namespace SystemService.Service.Interface.Menu
{
    /// <summary>
    /// 角色窗口关联服务接口
    /// </summary>
    public interface IRoleWindowAppService
    {
        /// <summary>
        /// 给角色分配窗口
        /// </summary>
        Task AssignWindowsToRoleAsync(long roleId, List<string> windowCodes);

        /// <summary>
        /// 根据角色ID查窗口编码列表
        /// </summary>
        Task<List<string>> GetWindowsByRoleIdAsync(long roleId);
    }
}
