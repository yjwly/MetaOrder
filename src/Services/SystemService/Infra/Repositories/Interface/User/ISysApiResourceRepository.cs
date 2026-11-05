using Shared.Db.Base;
using SystemService.Infra.Entities;

namespace SystemService.Infra.Repositories.Interface.User
{
    /// <summary>
    /// 后端API资源仓储接口
    /// </summary>
    public interface ISysApiResourceRepository 
    {
        /// <summary>
        /// 查询所有API列表
        /// </summary>
        Task<List<SysApiResource>> GetListAsync();
    }
}
