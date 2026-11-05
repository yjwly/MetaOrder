using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.User;
using SystemService.Service.Interface.User;

namespace SystemService.Service.Serv.User
{
    /// <summary>
    /// 后端API资源服务实现
    /// </summary>
    public class ApiResourceAppService : IApiResourceAppService
    {
        private ISqlSugarClient _db;
        private readonly ISysApiResourceRepository _apiRepo;

        public ApiResourceAppService(ISysApiResourceRepository apiRepo,ISqlSugarClient db)
        {
            _apiRepo = apiRepo;
            _db=db;
        }

        /// <summary>
        /// 查询所有API列表
        /// </summary>
        public async Task<List<SysApiResource>> GetListAsync()
        {
            return await _apiRepo.GetListAsync();
        }
        /// <summary>
        /// 添加API
        /// </summary>
        public async Task AddAsync(SysApiResource api)
        {
            await _db.Insertable(api).ExecuteCommandAsync();
        }

        /// <summary>
        /// 修改API
        /// </summary>
        public async Task<bool> UpdateAsync(SysApiResource api)
        {
            return await _db.Updateable(api).ExecuteCommandHasChangeAsync();
        }

        /// <summary>
        /// 删除API
        /// </summary>
        public async Task<bool> DeleteAsync(long id)
        {
            return await _db.Deleteable<SysApiResource>()
                .Where(x => x.Id == id)
                .ExecuteCommandHasChangeAsync();
        }

    }
}
