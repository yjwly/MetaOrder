using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface;
using SystemService.Infra.Repositories.Interface.Menu;
using SystemService.Service.Interface.Menu;

namespace SystemService.Service.Serv.Menu
{
    /// <summary>
    /// 窗口权限服务实现
    /// </summary>
    public class WindowAppService : IWindowAppService
    {
        private readonly ISysUserRoleRepository _userRoleRepo;
        private readonly ISysRoleWindowRepository _roleWindowRepo;
        private readonly ISysWpfWindowRepository _windowRepo;

        public WindowAppService(
            ISysUserRoleRepository userRoleRepo,
            ISysRoleWindowRepository roleWindowRepo,
            ISysWpfWindowRepository windowRepo)
        {
            _userRoleRepo = userRoleRepo;
            _roleWindowRepo = roleWindowRepo;
            _windowRepo = windowRepo;
        }

        /// <summary>
        /// 根据用户ID查窗口编码列表
        /// </summary>
        public async Task<List<string>> GetWindowsByUserIdAsync(long userId)
        {
            // 查这个用户有哪些角色
            var roleIds = await _userRoleRepo.GetRoleIdsByUserIdAsync(userId);

            // 查这些角色有哪些窗口
            var windowCodes = await _roleWindowRepo.GetWindowsByRoleIdsAsync(roleIds);

            return windowCodes.Distinct().ToList();
        }

        /// <summary>
        /// 查询所有窗口列表
        /// </summary>
        public async Task<List<SysWpfWindow>> GetListAsync()
        {
            return await _windowRepo.GetListAsync();
        }

        /// <summary>
        /// 添加窗口
        /// </summary>
        public async Task<long> AddAsync(string windowCode, string windowName)
        {
            var window = new SysWpfWindow
            {
                Id = SnowFlakeSingle.instance.getID(),
                WindowCode = windowCode,
                WindowName = windowName,
                CreatedTime = DateTime.Now
            };
            await _windowRepo.AddAsync(window);
            return window.Id;
        }

        /// <summary>
        /// 修改窗口
        /// </summary>
        public async Task<bool> UpdateAsync(long id, string windowCode, string windowName)
        {
            var window = await _windowRepo.GetByIdAsync(id);
            if (window == null)
                return false;

            window.WindowCode = windowCode;
            window.WindowName = windowName;
            window.UpdatedTime = DateTime.Now;
            return await _windowRepo.UpdateAsync(window);
        }

        /// <summary>
        /// 删除窗口
        /// </summary>
        public async Task<bool> DeleteAsync(long id)
        {
            return await _windowRepo.DeleteAsync(id);
        }
    }
}
