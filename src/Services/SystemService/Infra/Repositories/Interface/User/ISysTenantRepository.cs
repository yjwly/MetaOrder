using SystemService.Infra.Entities;

namespace SystemService.Infra.Repositories.Interface.User
{
    /// <summary>
    /// 租户仓储接口
    /// </summary>
    public interface ISysTenantRepository
    {
        /// <summary>
        /// 查询所有租户列表
        /// </summary>
        Task<List<SysTenant>> GetListAsync();

        /// <summary>
        /// 根据租户编码查租户
        /// </summary>
        Task<SysTenant> GetByCodeAsync(string code);
    }
}
