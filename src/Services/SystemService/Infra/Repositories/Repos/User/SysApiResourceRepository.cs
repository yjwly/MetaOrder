using Shared.Db.Base;
using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.User;

namespace SystemService.Infra.Repositories.Repos.User
{
    /// <summary>
    /// 后端API资源仓储实现
    /// </summary>
    public class SysApiResourceRepository : ISysApiResourceRepository
    {
        private readonly ISqlSugarClient _db;
        public SysApiResourceRepository(ISqlSugarClient db)
        {
            _db=db;
        }

        /// <summary>
        /// 查询所有API列表
        /// </summary>
        public async Task<List<SysApiResource>> GetListAsync()
        {
            return await _db.Queryable<SysApiResource>()
                .ToListAsync();
        }
    }
}
