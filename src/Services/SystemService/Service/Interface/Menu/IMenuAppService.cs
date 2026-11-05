using SystemService.Infra.Entities;

namespace SystemService.Service.Interface.Menu
{
    /// <summary>
    /// 菜单服务接口
    /// </summary>
    public interface IMenuAppService
    {
        /// <summary>
        /// 根据用户ID查菜单列表
        /// </summary>
        Task<List<SysMenu>> GetMenusByUserIdAsync(long userId);

        /// <summary>
        /// 查询所有菜单列表
        /// </summary>
        Task<List<SysMenu>> GetListAsync();

        /// <summary>
        /// 添加菜单
        /// </summary>
        Task<long> AddAsync(string name, string url, string icon, long parentId, int sort);

        /// <summary>
        /// 修改菜单
        /// </summary>
        Task<bool> UpdateAsync(long id, string name, string url, string icon, long parentId, int sort);

        /// <summary>
        /// 删除菜单
        /// </summary>
        Task<bool> DeleteAsync(long id);
    }
}
