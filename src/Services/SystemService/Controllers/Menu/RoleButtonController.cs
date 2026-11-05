using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SystemService.Service.Interface.Menu;

namespace SystemService.Controllers.Menu
{
    /// <summary>
    /// 角色按钮管理
    /// </summary>
    [ApiController]
    [Route("api/system/rolebutton/[action]")]
    [Authorize]
    public class RoleButtonController : ControllerBase
    {
        private readonly IRoleButtonAppService _roleButtonApp;

        public RoleButtonController(IRoleButtonAppService roleButtonApp)
        {
            _roleButtonApp = roleButtonApp;
        }

        /// <summary>
        /// 给角色分配按钮
        /// </summary>
        [HttpPost("assign/{roleId}")]
        public async Task<ApiResult> AssignButtonsToRole(long roleId, [FromBody] List<long> buttonIds)
        {
            await _roleButtonApp.AssignButtonsToRoleAsync(roleId, buttonIds);
            return ApiResult.Ok();
        }

        /// <summary>
        /// 根据角色ID查按钮ID列表
        /// </summary>
        [HttpGet("{roleId}")]
        public async Task<ApiResult<List<long>>> GetButtonIdsByRoleId(long roleId)
        {
            var list = await _roleButtonApp.GetButtonIdsByRoleIdAsync(roleId);
            return ApiResult<List<long>>.Ok(list);
        }
    }
}
