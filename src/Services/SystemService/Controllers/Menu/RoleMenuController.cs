using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SystemService.Service.Interface.Menu;

namespace SystemService.Controllers.Menu
{
    /// 角色菜单管理
    /// </summary>
    [ApiController]
    [Route("api/system/rolemenu/[action]")]
    [Authorize]
    public class RoleMenuController : ControllerBase
    {
        private readonly IRoleMenuAppService _roleMenuApp;

        public RoleMenuController(IRoleMenuAppService roleMenuApp)
        {
            _roleMenuApp = roleMenuApp;
        }

        /// <summary>
        /// 给角色分配菜单
        /// </summary>
        [HttpPost("assign/{roleId}")]
        public async Task<ApiResult> AssignMenusToRole(long roleId, [FromBody] List<long> menuIds)
        {
            await _roleMenuApp.AssignMenusToRoleAsync(roleId, menuIds);
            return ApiResult.Ok();
        }

        /// <summary>
        /// 根据角色ID查菜单ID列表
        /// </summary>
        [HttpGet("{roleId}")]
        public async Task<ApiResult<List<long>>> GetMenuIdsByRoleId(long roleId)
        {
            var list = await _roleMenuApp.GetMenuIdsByRoleIdAsync(roleId);
            return ApiResult<List<long>>.Ok(list);
        }
    }
}
