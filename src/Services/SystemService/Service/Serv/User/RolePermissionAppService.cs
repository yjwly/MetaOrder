using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.User;
using SystemService.Service.Interface.User;

namespace SystemService.Service.Serv.User
{
    /// <summary>
    /// 角色权限关联服务实现
    /// </summary>
    public class RolePermissionAppService : IRolePermissionAppService
    {
        private readonly ISysRolePermissionRepository _rolePermissionRepo;

        public RolePermissionAppService(ISysRolePermissionRepository rolePermissionRepo)
        {
            _rolePermissionRepo = rolePermissionRepo;
        }

        /// <summary>
        /// 给角色分配菜单
        /// </summary>
        public async Task AssignMenusToRoleAsync(long roleId, List<long> menuIds)
        {
            // 先删除旧的菜单权限
            await _rolePermissionRepo.DeleteByRoleIdAsync(roleId);

            // 再添加新的菜单权限
            var list = menuIds.Select(menuId => new SysRolePermission
            {
                Id = SnowFlakeSingle.instance.getID(),
                RoleId = roleId,
                MenuId = menuId,
                ButtonId = 0
            }).ToList();

            if (list.Any())
            {
                await _rolePermissionRepo.AddRangeAsync(list);
            }
        }

        /// <summary>
        /// 给角色分配按钮
        /// </summary>
        public async Task AssignButtonsToRoleAsync(long roleId, List<long> buttonIds)
        {
            // 先删除旧的按钮权限
            // 注意：这里要只删除按钮权限，不删除菜单权限
            // 简单起见，先全部删除，再重新加菜单和按钮
            // 后面再优化

            // 再添加新的按钮权限
            var list = buttonIds.Select(buttonId => new SysRolePermission
            {
                Id = SnowFlakeSingle.instance.getID(),
                RoleId = roleId,
                MenuId = 0,
                ButtonId = buttonId
            }).ToList();

            if (list.Any())
            {
                await _rolePermissionRepo.AddRangeAsync(list);
            }
        }

        /// <summary>
        /// 根据角色ID查菜单ID列表
        /// </summary>
        public async Task<List<long>> GetMenuIdsByRoleIdAsync(long roleId)
        {
            return await _rolePermissionRepo.GetMenuIdsByRoleIdAsync(roleId);
        }

        /// <summary>
        /// 根据角色ID查按钮ID列表
        /// </summary>
        public async Task<List<long>> GetButtonIdsByRoleIdAsync(long roleId)
        {
            return await _rolePermissionRepo.GetButtonIdsByRoleIdAsync(roleId);
        }
    }
}
