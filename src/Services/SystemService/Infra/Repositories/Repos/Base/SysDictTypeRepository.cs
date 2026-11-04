using Shared.Db.Base;
using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.Base;

namespace SystemService.Infra.Repositories.Repos.Base
{
    /// <summary>
    /// 字典类型仓储实现
    /// </summary>
    public class SysDictTypeRepository : BaseRepository<SysDictType>, ISysDictTypeRepository
    {
        public SysDictTypeRepository(ISqlSugarClient db) : base(db) { }
    }
}
