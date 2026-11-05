using Shared.Db.Base;
using SystemService.Infra.Entities;

namespace SystemService.Infra.Repositories.Interface.Menu
{
    /// <summary>
    /// 菜单仓储接口
    /// </summary>
    public interface ISysMenuRepository : IBaseRepository<SysMenu>
    {
        /// <summary>
        /// 根据角色ID列表查菜单列表
        /// </summary>
        Task<List<SysMenu>> GetMenusByRoleIdsAsync(List<long> roleIds);
    }
}
