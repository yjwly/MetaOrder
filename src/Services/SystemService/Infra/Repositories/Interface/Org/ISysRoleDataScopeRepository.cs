using SystemService.Infra.Entities;

namespace SystemService.Infra.Repositories.Interface.Org
{
    /// <summary>
    /// 角色数据范围仓储接口
    /// </summary>
    public interface ISysRoleDataScopeRepository
    {
        /// <summary>
        /// 根据角色ID查公司ID列表
        /// </summary>
        Task<List<long>> GetCompanyIdsByRoleIdAsync(long roleId);

        /// <summary>
        /// 根据角色ID删除所有数据范围
        /// </summary>
        Task DeleteByRoleIdAsync(long roleId);

        /// <summary>
        /// 批量添加
        /// </summary>
        Task AddRangeAsync(List<SysRoleDataScope> list);
    }
}
