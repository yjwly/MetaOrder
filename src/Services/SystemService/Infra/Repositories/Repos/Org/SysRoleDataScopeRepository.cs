using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.Org;

namespace SystemService.Infra.Repositories.Repos.Org
{
    /// <summary>
    /// 角色数据范围仓储实现
    /// </summary>
    public class SysRoleDataScopeRepository : ISysRoleDataScopeRepository
    {
        private readonly ISqlSugarClient _db;

        public SysRoleDataScopeRepository(ISqlSugarClient db)
        {
            _db = db;
        }

        /// <summary>
        /// 根据角色ID查公司ID列表
        /// </summary>
        public async Task<List<long>> GetCompanyIdsByRoleIdAsync(long roleId)
        {
            return await _db.Queryable<SysRoleDataScope>()
                .Where(x => x.RoleId == roleId)
                .Select(x => x.CompanyId)
                .ToListAsync();
        }

        /// <summary>
        /// 根据角色ID删除所有数据范围
        /// </summary>
        public async Task DeleteByRoleIdAsync(long roleId)
        {
            await _db.Deleteable<SysRoleDataScope>()
                .Where(x => x.RoleId == roleId)
                .ExecuteCommandAsync();
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        public async Task AddRangeAsync(List<SysRoleDataScope> list)
        {
            await _db.Insertable(list).ExecuteCommandAsync();
        }
    }
}
