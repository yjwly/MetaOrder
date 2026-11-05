using Shared.Db.Base;
using SystemService.Infra.Entities;

namespace SystemService.Infra.Repositories.Interface.Base
{
    /// <summary>
    /// 字典项仓储接口
    /// </summary>
    public interface ISysDictItemRepository : IBaseRepository<SysDictItem>
    {
        /// <summary>
        /// 根据字典类型ID查字典项列表
        /// </summary>
        Task<List<SysDictItem>> GetListByDictTypeIdAsync(long dictTypeId);
    }
}
