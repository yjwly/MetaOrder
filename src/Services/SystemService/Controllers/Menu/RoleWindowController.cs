using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SystemService.Service.Interface.Menu;

namespace SystemService.Controllers.Menu
{
    /// <summary>
    /// 角色窗口管理
    /// </summary>
    [ApiController]
    [Route("api/system/rolewindow/[action]")]
    [Authorize]
    public class RoleWindowController : ControllerBase
    {
        private readonly IRoleWindowAppService _roleWindowApp;

        public RoleWindowController(IRoleWindowAppService roleWindowApp)
        {
            _roleWindowApp = roleWindowApp;
        }

        /// <summary>
        /// 给角色分配窗口
        /// </summary>
        [HttpPost("assign/{roleId}")]
        public async Task<ApiResult> AssignWindowsToRole(long roleId, [FromBody] List<string> windowCodes)
        {
            await _roleWindowApp.AssignWindowsToRoleAsync(roleId, windowCodes);
            return ApiResult.Ok();
        }

        /// <summary>
        /// 根据角色ID查窗口编码列表
        /// </summary>
        [HttpGet("{roleId}")]
        public async Task<ApiResult<List<string>>> GetWindowsByRoleId(long roleId)
        {
            var list = await _roleWindowApp.GetWindowsByRoleIdAsync(roleId);
            return ApiResult<List<string>>.Ok(list);
        }
    }
}
