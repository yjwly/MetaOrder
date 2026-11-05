using Shared.Db.Base;
using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.Menu;

namespace SystemService.Infra.Repositories.Repos.Menu
{
    /// <summary>
    /// WPF窗口仓储实现
    /// </summary>
    public class SysWpfWindowRepository : BaseRepository<SysWpfWindow>, ISysWpfWindowRepository
    {
        public SysWpfWindowRepository(ISqlSugarClient db) : base(db) { }

        /// <summary>
        /// 查询所有窗口列表
        /// </summary>
        public async Task<List<SysWpfWindow>> GetListAsync()
        {
            return await _db.Queryable<SysWpfWindow>()
                .ToListAsync();
        }
    }
}
