using Shared.Db.Base;
using SystemService.Infra.Entities;

namespace SystemService.Infra.Repositories.Interface.Org
{
    /// <summary>
    /// 组织仓储接口
    /// </summary>
    public interface ISysOrgRepository : IBaseRepository<SysOrg>
    {
        /// <summary>
        /// 查询所有组织列表
        /// </summary>
        Task<List<SysOrg>> GetListAsync();
    }
}
