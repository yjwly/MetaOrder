using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SystemService.Service.Interface.User;

namespace SystemService.Controllers.User
{
    /// <summary>
    /// 角色权限管理
    /// </summary>
    [ApiController]
    [Route("api/system/rolepermission/[action]")]
    [Authorize]
    public class RolePermissionController : ControllerBase
    {
        private readonly IRolePermissionAppService _rolePermissionApp;

        public RolePermissionController(IRolePermissionAppService rolePermissionApp)
        {
            _rolePermissionApp = rolePermissionApp;
        }

        /// <summary>
        /// 给角色分配菜单
        /// </summary>
        [HttpPost("assignmenu/{roleId}")]
        public async Task<ApiResult> AssignMenusToRole(long roleId, [FromBody] List<long> menuIds)
        {
            await _rolePermissionApp.AssignMenusToRoleAsync(roleId, menuIds);
            return ApiResult.Ok();
        }

        /// <summary>
        /// 给角色分配按钮
        /// </summary>
        [HttpPost("assignbutton/{roleId}")]
        public async Task<ApiResult> AssignButtonsToRole(long roleId, [FromBody] List<long> buttonIds)
        {
            await _rolePermissionApp.AssignButtonsToRoleAsync(roleId, buttonIds);
            return ApiResult.Ok();
        }

        /// <summary>
        /// 根据角色ID查菜单ID列表
        /// </summary>
        [HttpGet("menu/{roleId}")]
        public async Task<ApiResult<List<long>>> GetMenuIdsByRoleId(long roleId)
        {
            var list = await _rolePermissionApp.GetMenuIdsByRoleIdAsync(roleId);
            return ApiResult<List<long>>.Ok(list);
        }

        /// <summary>
        /// 根据角色ID查按钮ID列表
        /// </summary>
        [HttpGet("button/{roleId}")]
        public async Task<ApiResult<List<long>>> GetButtonIdsByRoleId(long roleId)
        {
            var list = await _rolePermissionApp.GetButtonIdsByRoleIdAsync(roleId);
            return ApiResult<List<long>>.Ok(list);
        }
    }
}
