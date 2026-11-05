using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.Menu;
using SystemService.Service.Interface.Menu;

namespace SystemService.Service.Serv.Menu
{
    /// <summary>
    /// 角色菜单关联服务实现
    /// </summary>
    public class RoleMenuAppService : IRoleMenuAppService
    {
        private readonly ISysRoleMenuRepository _roleMenuRepo;

        public RoleMenuAppService(ISysRoleMenuRepository roleMenuRepo)
        {
            _roleMenuRepo = roleMenuRepo;
        }

        /// <summary>
        /// 给角色分配菜单
        /// </summary>
        public async Task AssignMenusToRoleAsync(long roleId, List<long> menuIds)
        {
            // 先删除旧的
            await _roleMenuRepo.DeleteByRoleIdAsync(roleId);

            // 再添加新的
            var list = menuIds.Select(menuId => new SysRoleMenu
            {
                RoleId = roleId,
                MenuId = menuId
            }).ToList();

            if (list.Any())
            {
                await _roleMenuRepo.AddRangeAsync(list);
            }
        }

        /// <summary>
        /// 根据角色ID查菜单ID列表
        /// </summary>
        public async Task<List<long>> GetMenuIdsByRoleIdAsync(long roleId)
        {
            return await _roleMenuRepo.GetMenuIdsByRoleIdAsync(roleId);
        }
    }
}
