using Shared.Db.Base;
using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.Menu;

namespace SystemService.Infra.Repositories.Repos.Menu
{
    /// <summary>
    /// 菜单仓储实现
    /// </summary>
    public class SysMenuRepository : BaseRepository<SysMenu>, ISysMenuRepository
    {
        public SysMenuRepository(ISqlSugarClient db) : base(db) { }

        /// <summary>
        /// 根据角色ID列表查菜单列表
        /// </summary>
        public async Task<List<SysMenu>> GetMenusByRoleIdsAsync(List<long> roleIds)
        {
            return await _db.Queryable<SysRoleMenu>()
                .InnerJoin<SysMenu>((rm, m) => rm.MenuId == m.Id)
                .Where((rm, m) => roleIds.Contains(rm.RoleId))
                .Select((rm, m) => m)
                .ToListAsync();
        }
    }
}
