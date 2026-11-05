using SystemService.Infra.Entities;

namespace SystemService.Service.Interface.Menu
{
    /// <summary>
    /// 窗口权限服务接口
    /// </summary>
    public interface IWindowAppService
    {
        /// <summary>
        /// 根据用户ID查窗口编码列表
        /// </summary>
        Task<List<string>> GetWindowsByUserIdAsync(long userId);

        /// <summary>
        /// 查询所有窗口列表
        /// </summary>
        Task<List<SysWpfWindow>> GetListAsync();

        /// <summary>
        /// 添加窗口
        /// </summary>
        Task<long> AddAsync(string windowCode, string windowName);

        /// <summary>
        /// 修改窗口
        /// </summary>
        Task<bool> UpdateAsync(long id, string windowCode, string windowName);

        /// <summary>
        /// 删除窗口
        /// </summary>
        Task<bool> DeleteAsync(long id);
    }
}
