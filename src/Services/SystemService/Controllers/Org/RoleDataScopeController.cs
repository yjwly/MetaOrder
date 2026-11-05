using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SystemService.Service.Interface.Org;

namespace SystemService.Controllers.Org
{
    /// <summary>
    /// 角色数据范围管理
    /// </summary>
    [ApiController]
    [Route("api/system/roledatascope/[action]")]
    [Authorize]
    public class RoleDataScopeController : ControllerBase
    {
        private readonly IRoleDataScopeAppService _roleDataScopeApp;

        public RoleDataScopeController(IRoleDataScopeAppService roleDataScopeApp)
        {
            _roleDataScopeApp = roleDataScopeApp;
        }

        /// <summary>
        /// 给角色分配数据范围
        /// </summary>
        [HttpPost("assign/{roleId}")]
        public async Task<ApiResult> AssignDataScopeToRole(long roleId, [FromBody] List<long> companyIds)
        {
            await _roleDataScopeApp.AssignDataScopeToRoleAsync(roleId, companyIds);
            return ApiResult.Ok();
        }

        /// <summary>
        /// 根据角色ID查公司ID列表
        /// </summary>
        [HttpGet("{roleId}")]
        public async Task<ApiResult<List<long>>> GetCompanyIdsByRoleId(long roleId)
        {
            var list = await _roleDataScopeApp.GetCompanyIdsByRoleIdAsync(roleId);
            return ApiResult<List<long>>.Ok(list);
        }
    }
}
