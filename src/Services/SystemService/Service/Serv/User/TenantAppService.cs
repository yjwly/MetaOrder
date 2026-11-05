using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.User;
using SystemService.Service.Interface.User;

namespace SystemService.Service.Serv.User
{
    /// <summary>
    /// 租户服务实现
    /// </summary>
    public class TenantAppService : ITenantAppService
    {
        private readonly ISysTenantRepository _tenantRepo;
        private readonly ISqlSugarClient _db;

        public TenantAppService(ISysTenantRepository tenantRepo, ISqlSugarClient db)
        {
            _tenantRepo = tenantRepo;
            _db=db;
        }

        /// <summary>
        /// 查询所有租户列表
        /// </summary>
        public async Task<List<SysTenant>> GetListAsync()
        {
            return await _tenantRepo.GetListAsync();
        }
        /// <summary>
        /// 添加租户
        /// </summary>
        public async Task AddAsync(SysTenant tenant)
        {
            await _db.Insertable(tenant).ExecuteCommandAsync();
        }

        /// <summary>
        /// 修改租户
        /// </summary>
        public async Task<bool> UpdateAsync(SysTenant tenant)
        {
            return await _db.Updateable(tenant).ExecuteCommandHasChangeAsync();
        }

        /// <summary>
        /// 根据ID查租户
        /// </summary>
        public async Task<SysTenant> GetByIdAsync(long id)
        {
            return await _db.Queryable<SysTenant>()
                .Where(x => x.Id == id)
                .FirstAsync();
        }

        /// <summary>
        /// 删除租户
        /// </summary>
        public async Task<bool> DeleteAsync(long id)
        {
            return await _db.Deleteable<SysTenant>()
                .Where(x => x.Id == id)
                .ExecuteCommandHasChangeAsync();
        }


    }
}
