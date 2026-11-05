using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface;
using SystemService.Infra.Repositories.Interface.Menu;
using SystemService.Service.Interface.Menu;

namespace SystemService.Service.Serv.Menu
{
    /// <summary>
    /// 菜单服务实现
    /// </summary>
    public class MenuAppService : IMenuAppService
    {
        private readonly ISysUserRoleRepository _userRoleRepo;
        private readonly ISysMenuRepository _menuRepo;

        public MenuAppService(
            ISysUserRoleRepository userRoleRepo,
            ISysMenuRepository menuRepo)
        {
            _userRoleRepo = userRoleRepo;
            _menuRepo = menuRepo;
        }

        /// <summary>
        /// 根据用户ID查菜单列表
        /// </summary>
        public async Task<List<SysMenu>> GetMenusByUserIdAsync(long userId)
        {
            // 查这个用户有哪些角色
            var roleIds = await _userRoleRepo.GetRoleIdsByUserIdAsync(userId);

            // 查这些角色有哪些菜单
            var menus = await _menuRepo.GetMenusByRoleIdsAsync(roleIds);

            return menus;
        }

        /// <summary>
        /// 查询所有菜单列表
        /// </summary>
        public async Task<List<SysMenu>> GetListAsync()
        {
            return await _menuRepo.GetListAsync(x => true);
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        public async Task<long> AddAsync(string name, string url, string icon, long parentId, int sort)
        {
            var menu = new SysMenu
            {
                Id = SnowFlakeSingle.instance.getID(),
                Name = name,
                Url = url,
                Icon = icon,
                ParentId = parentId,
                Sort = sort,
                CreatedTime = DateTime.Now
            };
            await _menuRepo.AddAsync(menu);
            return menu.Id;
        }

        /// <summary>
        /// 修改菜单
        /// </summary>
        public async Task<bool> UpdateAsync(long id, string name, string url, string icon, long parentId, int sort)
        {
            var menu = await _menuRepo.GetByIdAsync(id);
            if (menu == null)
                return false;

            menu.Name = name;
            menu.Url = url;
            menu.Icon = icon;
            menu.ParentId = parentId;
            menu.Sort = sort;
            menu.UpdatedTime = DateTime.Now;
            return await _menuRepo.UpdateAsync(menu);
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        public async Task<bool> DeleteAsync(long id)
        {
            return await _menuRepo.DeleteAsync(id);
        }
    }
}
