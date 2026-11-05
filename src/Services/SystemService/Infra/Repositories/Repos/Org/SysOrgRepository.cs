using Shared.Db.Base;
using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.Org;

namespace SystemService.Infra.Repositories.Repos.Org
{
    /// <summary>
    /// 组织仓储实现
    /// </summary>
    public class SysOrgRepository : BaseRepository<SysOrg>, ISysOrgRepository
    {
        public SysOrgRepository(ISqlSugarClient db) : base(db) { }

        /// <summary>
        /// 查询所有组织列表
        /// </summary>
        public async Task<List<SysOrg>> GetListAsync()
        {
            return await _db.Queryable<SysOrg>()
                .OrderBy(x => x.Sort)
                .ToListAsync();
        }
    }
}
