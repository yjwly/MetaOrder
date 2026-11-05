using Shared.Db.Base;
using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.Base;

namespace SystemService.Infra.Repositories.Repos.Base
{
    /// <summary>
    /// 字典项仓储实现
    /// </summary>
    public class SysDictItemRepository : BaseRepository<SysDictItem>, ISysDictItemRepository
    {
        public SysDictItemRepository(ISqlSugarClient db) : base(db) { }

        /// <summary>
        /// 根据字典类型ID查字典项列表
        /// </summary>
        public async Task<List<SysDictItem>> GetListByDictTypeIdAsync(long dictTypeId)
        {
            return await _db.Queryable<SysDictItem>()
                .Where(x => x.DictTypeId == dictTypeId)
                .OrderBy(x => x.Sort)
                .ToListAsync();
        }
    }
}
