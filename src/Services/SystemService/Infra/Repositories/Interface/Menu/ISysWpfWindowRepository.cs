using Shared.Db.Base;
using SystemService.Infra.Entities;

namespace SystemService.Infra.Repositories.Interface.Menu
{
    /// <summary>
    /// WPF窗口仓储接口
    /// </summary>
    public interface ISysWpfWindowRepository : IBaseRepository<SysWpfWindow>
    {
        /// <summary>
        /// 查询所有窗口列表
        /// </summary>
        Task<List<SysWpfWindow>> GetListAsync();
    }
}
