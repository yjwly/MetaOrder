using SystemService.Infra.Entities;

namespace SystemService.Service.Interface.User
{
    /// <summary>
    /// 后端API资源服务接口
    /// </summary>
    public interface IApiResourceAppService
    {
        /// <summary>
        /// 查询所有API列表
        /// </summary>
        Task<List<SysApiResource>> GetListAsync();

        /// <summary>
        /// 添加API
        /// </summary>
        Task AddAsync(SysApiResource api);

        /// <summary>
        /// 修改API
        /// </summary>
        Task<bool> UpdateAsync(SysApiResource api);

        /// <summary>
        /// 删除API
        /// </summary>
        Task<bool> DeleteAsync(long id);
    }
}
