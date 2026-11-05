using SystemService.Infra.Entities;
using SystemService.Infra.Repositories.Interface.Org;
using SystemService.Service.Interface.Org;

namespace SystemService.Service.Serv.Org
{
    /// <summary>
    /// 角色数据范围服务实现
    /// </summary>
    public class RoleDataScopeAppService : IRoleDataScopeAppService
    {
        private readonly ISysRoleDataScopeRepository _roleDataScopeRepo;

        public RoleDataScopeAppService(ISysRoleDataScopeRepository roleDataScopeRepo)
        {
            _roleDataScopeRepo = roleDataScopeRepo;
        }

        /// <summary>
        /// 给角色分配数据范围
        /// </summary>
        public async Task AssignDataScopeToRoleAsync(long roleId, List<long> companyIds)
        {
            // 先删除旧的
            await _roleDataScopeRepo.DeleteByRoleIdAsync(roleId);

            // 再添加新的
            var list = companyIds.Select(companyId => new SysRoleDataScope
            {
                RoleId = roleId,
                CompanyId = companyId
            }).ToList();

            if (list.Any())
            {
                await _roleDataScopeRepo.AddRangeAsync(list);
            }
        }

        /// <summary>
        /// 根据角色ID查公司ID列表
        /// </summary>
        public async Task<List<long>> GetCompanyIdsByRoleIdAsync(long roleId)
        {
            return await _roleDataScopeRepo.GetCompanyIdsByRoleIdAsync(roleId);
        }
    }
}
