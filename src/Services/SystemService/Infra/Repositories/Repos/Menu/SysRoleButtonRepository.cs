using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.Menu;

namespace SystemService.Infra.Repositories.Repos.Menu
{
    /// <summary>
    /// 角色按钮关联仓储实现
    /// </summary>
    public class SysRoleButtonRepository : ISysRoleButtonRepository
    {
        private readonly ISqlSugarClient _db;

        public SysRoleButtonRepository(ISqlSugarClient db)
        {
            _db = db;
        }

        /// <summary>
        /// 根据角色ID查按钮ID列表
        /// </summary>
        public async Task<List<long>> GetButtonIdsByRoleIdAsync(long roleId)
        {
            return await _db.Queryable<SysRoleButton>()
                .Where(x => x.RoleId == roleId)
                .Select(x => x.ButtonId)
                .ToListAsync();
        }

        /// <summary>
        /// 根据角色ID删除所有按钮
        /// </summary>
        public async Task DeleteByRoleIdAsync(long roleId)
        {
            await _db.Deleteable<SysRoleButton>()
                .Where(x => x.RoleId == roleId)
                .ExecuteCommandAsync();
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        public async Task AddRangeAsync(List<SysRoleButton> list)
        {
            await _db.Insertable(list).ExecuteCommandAsync();
        }
    }
}
