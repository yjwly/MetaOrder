using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.Menu;

namespace SystemService.Infra.Repositories.Repos.Menu
{
    /// <summary>
    /// 角色菜单关联仓储实现
    /// </summary>
    public class SysRoleMenuRepository : ISysRoleMenuRepository
    {
        private readonly ISqlSugarClient _db;

        public SysRoleMenuRepository(ISqlSugarClient db)
        {
            _db = db;
        }

        /// <summary>
        /// 根据角色ID查菜单ID列表
        /// </summary>
        public async Task<List<long>> GetMenuIdsByRoleIdAsync(long roleId)
        {
            return await _db.Queryable<SysRoleMenu>()
                .Where(x => x.RoleId == roleId)
                .Select(x => x.MenuId)
                .ToListAsync();
        }

        /// <summary>
        /// 根据角色ID删除所有菜单
        /// </summary>
        public async Task DeleteByRoleIdAsync(long roleId)
        {
            await _db.Deleteable<SysRoleMenu>()
                .Where(x => x.RoleId == roleId)
                .ExecuteCommandAsync();
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        public async Task AddRangeAsync(List<SysRoleMenu> list)
        {
            await _db.Insertable(list).ExecuteCommandAsync();
        }
    }
}
