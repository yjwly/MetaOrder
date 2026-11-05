using Shared.Db.Base;
using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.Menu;

namespace SystemService.Infra.Repositories.Repos.Menu
{
    /// <summary>
    /// 按钮仓储实现
    /// </summary>
    public class SysButtonRepository : BaseRepository<SysButton>, ISysButtonRepository
    {
        public SysButtonRepository(ISqlSugarClient db) : base(db) { }

        /// <summary>
        ///根据菜单ID查按钮列表
        /// </summary>
        public async Task<List<SysButton>> GetListByMenuIdAsync(long menuId)
        {
            return await _db.Queryable<SysButton>()
                .Where(x => x.MenuId == menuId)
                .ToListAsync();
        }

        /// <summary>
        ///根据角色ID列表查按钮列表
        /// </summary>
        public async Task<List<SysButton>> GetButtonsByRoleIdsAsync(List<long> roleIds)
        {
            return await _db.Queryable<SysRoleButton>()
                .InnerJoin<SysButton>((rb, b) => rb.ButtonId == b.Id)
                .Where((rb, b) => roleIds.Contains(rb.RoleId))
                .Select((rb, b) => b)
                .ToListAsync();
        }
    }
}
