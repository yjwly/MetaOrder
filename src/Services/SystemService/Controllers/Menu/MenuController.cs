using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SystemService.Infra.Entities;
using SystemService.Service.Interface.Menu;

namespace SystemService.Controllers.Menu
{
    /// <summary>
    /// 菜单管理
    /// </summary>
    [ApiController]
    [Route("api/system/menu/[action]")]
    [Authorize]
    public class MenuController : ControllerBase
    {
        private readonly IMenuAppService _menuApp;

        public MenuController(IMenuAppService menuApp)
        {
            _menuApp = menuApp;
        }

        /// <summary>
        /// 根据用户ID查菜单列表
        /// </summary>
        [HttpGet("user/{userId}")]
        public async Task<ApiResult<List<SysMenu>>> GetMenusByUserId(long userId)
        {
            var list = await _menuApp.GetMenusByUserIdAsync(userId);
            return ApiResult<List<SysMenu>>.Ok(list);
        }

        /// <summary>
        /// 查询所有菜单列表
        /// </summary>
        [HttpGet]
        public async Task<ApiResult<List<SysMenu>>> GetList()
        {
            var list = await _menuApp.GetListAsync();
            return ApiResult<List<SysMenu>>.Ok(list);
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        [HttpPost]
        public async Task<ApiResult<long>> Add([FromBody] dynamic body)
        {
            var id = await _menuApp.AddAsync(body.name, body.url, body.icon, body.parentId, body.sort);
            return ApiResult<long>.Ok(id);
        }

        /// <summary>
        /// 修改菜单
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ApiResult<bool>> Update(long id, [FromBody] dynamic body)
        {
            var result = await _menuApp.UpdateAsync(id, body.name, body.url, body.icon, body.parentId, body.sort);
            return ApiResult<bool>.Ok(result);
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ApiResult<bool>> Delete(long id)
        {
            var result = await _menuApp.DeleteAsync(id);
            return ApiResult<bool>.Ok(result);
        }
    }
}
