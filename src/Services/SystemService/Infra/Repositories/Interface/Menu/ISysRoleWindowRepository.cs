using SystemService.Infra.Entities;

namespace SystemService.Infra.Repositories.Interface.Menu
{
    /// <summary>
    /// 角色窗口关联仓储接口
    /// </summary>
    public interface ISysRoleWindowRepository
    {
        /// <summary>
        /// 根据角色ID列表查窗口编码列表
        /// </summary>
        Task<List<string>> GetWindowsByRoleIdsAsync(List<long> roleIds);

        /// <summary>
        /// 根据角色ID删除所有窗口
        /// </summary>
        Task DeleteByRoleIdAsync(long roleId);

        /// <summary>
        /// 批量添加
        /// </summary>
        Task AddRangeAsync(List<SysRoleWindow> list);
    }
}
