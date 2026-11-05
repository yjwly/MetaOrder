using SystemService.Infra.Entities;

namespace SystemService.Service.Interface.User
{
    /// <summary>
    /// 租户服务接口
    /// </summary>
    public interface ITenantAppService
    {
        /// <summary>
        /// 查询所有租户列表
        /// </summary>
        Task<List<SysTenant>> GetListAsync();
        /// <summary>
        /// 添加租户
        /// </summary>
        Task AddAsync(SysTenant tenant);

        /// <summary>
        /// 修改租户
        /// </summary>
        Task<bool> UpdateAsync(SysTenant tenant);

        /// <summary>
        /// 根据ID查租户
        /// </summary>
        Task<SysTenant> GetByIdAsync(long id);

        /// <summary>
        /// 删除租户
        /// </summary>
        Task<bool> DeleteAsync(long id);


    }
}
