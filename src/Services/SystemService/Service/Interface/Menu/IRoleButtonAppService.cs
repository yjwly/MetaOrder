namespace SystemService.Service.Interface.Menu
{
    /// <summary>
    /// 角色按钮关联服务接口
    /// </summary>
    public interface IRoleButtonAppService
    {
        /// <summary>
        /// 给角色分配按钮
        /// </summary>
        Task AssignButtonsToRoleAsync(long roleId, List<long> buttonIds);

        /// <summary>
        /// 根据角色ID查按钮ID列表
        /// </summary>
        Task<List<long>> GetButtonIdsByRoleIdAsync(long roleId);
    }
}
