namespace SystemService.Service.Interface.Org
{
    /// <summary>
    /// 角色数据范围服务接口
    /// </summary>
    public interface IRoleDataScopeAppService
    {
        /// <summary>
        /// 给角色分配数据范围
        /// </summary>
        Task AssignDataScopeToRoleAsync(long roleId, List<long> companyIds);

        /// <summary>
        /// 根据角色ID查公司ID列表
        /// </summary>
        Task<List<long>> GetCompanyIdsByRoleIdAsync(long roleId);
    }
}
