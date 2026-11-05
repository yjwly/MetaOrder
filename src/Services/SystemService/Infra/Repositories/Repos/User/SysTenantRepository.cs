using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.User;

namespace SystemService.Infra.Repositories.Repos.User
{
    public class SysTenantRepository : ISysTenantRepository
    {
        private readonly ISqlSugarClient _db;

        public SysTenantRepository(ISqlSugarClient db)
        {
            _db = db;
        }

        /// <summary>
        /// 查询所有租户列表
        /// </summary>
        public async Task<List<SysTenant>> GetListAsync()
        {
            return await _db.Queryable<SysTenant>().ToListAsync();
        }

        /// <summary>
        /// 根据租户编码查租户
        /// </summary>
        public async Task<SysTenant> GetByCodeAsync(string code)
        {
            return await _db.Queryable<SysTenant>()
                .Where(x => x.Code == code)
                .FirstAsync();
        }
    }
}
