using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.Menu;
using SystemService.Service.Interface.Menu;

namespace SystemService.Service.Serv.Menu
{
    /// <summary>
    /// 角色按钮关联服务实现
    /// </summary>
    public class RoleButtonAppService : IRoleButtonAppService
    {
        private readonly ISysRoleButtonRepository _roleButtonRepo;

        public RoleButtonAppService(ISysRoleButtonRepository roleButtonRepo)
        {
            _roleButtonRepo = roleButtonRepo;
        }

        /// <summary>
        /// 给角色分配按钮
        /// </summary>
        public async Task AssignButtonsToRoleAsync(long roleId, List<long> buttonIds)
        {
            // 先删除旧的
            await _roleButtonRepo.DeleteByRoleIdAsync(roleId);

            // 再添加新的
            var list = buttonIds.Select(buttonId => new SysRoleButton
            {
                RoleId = roleId,
                ButtonId = buttonId
            }).ToList();

            if (list.Any())
            {
                await _roleButtonRepo.AddRangeAsync(list);
            }
        }

        /// <summary>
        /// 根据角色ID查按钮ID列表
        /// </summary>
        public async Task<List<long>> GetButtonIdsByRoleIdAsync(long roleId)
        {
            return await _roleButtonRepo.GetButtonIdsByRoleIdAsync(roleId);
        }
    }
}
