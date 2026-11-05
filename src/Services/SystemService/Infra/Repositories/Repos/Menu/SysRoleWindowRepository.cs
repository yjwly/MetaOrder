using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.Menu;

namespace SystemService.Infra.Repositories.Repos.Menu
{
    /// <summary>
    /// 角色窗口关联仓储实现
    /// </summary>
    public class SysRoleWindowRepository : ISysRoleWindowRepository
    {
        private readonly ISqlSugarClient _db;

        public SysRoleWindowRepository(ISqlSugarClient db)
        {
            _db = db;
        }

        /// <summary>
        /// 根据角色ID列表查窗口编码列表
        /// </summary>
        public async Task<List<string>> GetWindowsByRoleIdsAsync(List<long> roleIds)
        {
            return await _db.Queryable<SysRoleWindow>()
                .Where(x => roleIds.Contains(x.RoleId))
                .Select(x => x.WindowCode)
                .ToListAsync();
        }

        /// <summary>
        /// 根据角色ID删除所有窗口
        /// </summary>
        public async Task DeleteByRoleIdAsync(long roleId)
        {
            await _db.Deleteable<SysRoleWindow>()
                .Where(x => x.RoleId == roleId)
                .ExecuteCommandAsync();
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        public async Task AddRangeAsync(List<SysRoleWindow> list)
        {
            await _db.Insertable(list).ExecuteCommandAsync();
        }
    }
}
