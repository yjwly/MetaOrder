using Shared.Db.Base;
using SystemService.Infra.Entities;

namespace SystemService.Infra.Repositories.Interface.Menu
{
    /// <summary>
    /// 按钮仓储接口
    /// </summary>
    public interface ISysButtonRepository : IBaseRepository<SysButton>
    {
        /// <summary>
        //根据菜单ID查按钮列表
        /// </summary>
        Task<List<SysButton>> GetListByMenuIdAsync(long menuId);

        /// <summary>
        ///根据角色ID列表查按钮列表
        /// </summary>
        Task<List<SysButton>> GetButtonsByRoleIdsAsync(List<long> roleIds);
    }
}
