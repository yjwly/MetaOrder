using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SystemService.Infra.Dtos.Base;
using SystemService.Infra.Dtos.User;
using SystemService.Service.Interface.User;

namespace SystemService.Controllers.User
{
    /// <summary>
    /// 用户角色关联表
    /// </summary>
    [Route("api/system/UserRole/[action]")]
    [ApiController]
    [Authorize]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleAppService _userRoleApp;

        public UserRoleController(IUserRoleAppService userRoleApp)
        {
            _userRoleApp = userRoleApp;
        }

        /// <summary>
        /// 根据用户ID查角色ID列表
        /// </summary>
        [HttpGet("{userId}")]
        public async Task<ApiResult<List<long>>> GetRoleIdsByUserId(long userId)
        {
            var list = await _userRoleApp.GetRoleIdsByUserIdAsync(userId);
            return ApiResult<List<long>>.Ok(list);
        }

        /// <summary>
        /// 分配角色
        /// </summary>
        [HttpPost("assign")]
        public async Task<ApiResult> AssignRoles([FromBody] UserRoleDto dto)
        {
            await _userRoleApp.AssignRolesAsync(dto);
            return ApiResult.Ok();
        }

        /// <summary>
        /// 获取用户角色树形结构
        /// </summary>
        [HttpGet]
        public async Task<ApiResult<List<TreeNodeDto>>> GetTree()
        {
            var tree = await _userRoleApp.GetUserRoleTreeAsync();
            return ApiResult<List<TreeNodeDto>>.Ok(tree);
        }
    }
}
