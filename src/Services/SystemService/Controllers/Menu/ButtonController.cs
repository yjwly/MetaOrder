using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SystemService.Infra.Entities;
using SystemService.Service.Interface.Menu;

namespace SystemService.Controllers.Menu
{
    /// <summary>
    /// 按钮管理
    /// </summary>
    [ApiController]
    [Route("api/system/button/[action]")]
    [Authorize]
    public class ButtonController : ControllerBase
    {
        private readonly IButtonAppService _buttonApp;

        public ButtonController(IButtonAppService buttonApp)
        {
            _buttonApp = buttonApp;
        }

        /// <summary>
        ///根据用户ID查按钮编码列表
        /// </summary>
        [HttpGet("user/{userId}")]
        public async Task<ApiResult<List<string>>> GetButtonsByUserId(long userId)
        {
            var list = await _buttonApp.GetButtonsByUserIdAsync(userId);
            return ApiResult<List<string>>.Ok(list);
        }

        /// <summary>
        ///根据菜单ID查按钮列表
        /// </summary>
        [HttpGet("menu/{menuId}")]
        public async Task<ApiResult<List<SysButton>>> GetListByMenuId(long menuId)
        {
            var list = await _buttonApp.GetListByMenuIdAsync(menuId);
            return ApiResult<List<SysButton>>.Ok(list);
        }

        /// <summary>
        ///添加按钮
        /// </summary>
        [HttpPost]
        public async Task<ApiResult<long>> Add([FromBody] dynamic body)
        {
            var id = await _buttonApp.AddAsync(body.menuId, body.name, body.code);
            return ApiResult<long>.Ok(id);
        }

        /// <summary>
        /// 修改按钮
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ApiResult<bool>> Update(long id, [FromBody] dynamic body)
        {
            var result = await _buttonApp.UpdateAsync(id, body.name, body.code);
            return ApiResult<bool>.Ok(result);
        }

        /// <summary>
        ///删除按钮
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ApiResult<bool>> Delete(long id)
        {
            var result = await _buttonApp.DeleteAsync(id);
            return ApiResult<bool>.Ok(result);
        }
    }
}
