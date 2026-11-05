using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.Menu;
using SystemService.Service.Interface.Menu;

namespace SystemService.Service.Serv.Menu
{
    /// <summary>
    /// 角色窗口关联服务实现
    /// </summary>
    public class RoleWindowAppService : IRoleWindowAppService
    {
        private readonly ISysRoleWindowRepository _roleWindowRepo;

        public RoleWindowAppService(ISysRoleWindowRepository roleWindowRepo)
        {
            _roleWindowRepo = roleWindowRepo;
        }

        /// <summary>
        /// 给角色分配窗口
        /// </summary>
        public async Task AssignWindowsToRoleAsync(long roleId, List<string> windowCodes)
        {
            // 先删除旧的
            await _roleWindowRepo.DeleteByRoleIdAsync(roleId);

            // 再添加新的
            var list = windowCodes.Select(code => new SysRoleWindow
            {
                RoleId = roleId,
                WindowCode = code
            }).ToList();

            if (list.Any())
            {
                await _roleWindowRepo.AddRangeAsync(list);
            }
        }

        /// <summary>
        /// 根据角色ID查窗口编码列表
        /// </summary>
        public async Task<List<string>> GetWindowsByRoleIdAsync(long roleId)
        {
            return await _roleWindowRepo.GetWindowsByRoleIdsAsync(new List<long> { roleId });
        }
    }
}
