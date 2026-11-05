using SystemService.Infra.Entities;

namespace SystemService.Service.Interface.Menu
{
    /// <summary>
    /// 按钮服务接口
    /// </summary>
    public interface IButtonAppService
    {
        /// <summary>
        ///根据用户ID查按钮编码列表
        /// </summary>
        Task<List<string>> GetButtonsByUserIdAsync(long userId);

        /// <summary>
        ///根据菜单ID查按钮列表
        /// </summary>
        Task<List<SysButton>> GetListByMenuIdAsync(long menuId);

        /// <summary>
        ///添加按钮
        /// </summary>
        Task<long> AddAsync(long menuId, string name, string code);

        /// <summary>
        ///修改按钮
        /// </summary>
        Task<bool> UpdateAsync(long id, string name, string code);

        /// <summary>
        ///删除按钮
        /// </summary>
        Task<bool> DeleteAsync(long id);
    }
}
