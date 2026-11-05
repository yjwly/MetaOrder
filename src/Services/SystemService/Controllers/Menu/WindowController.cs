using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SystemService.Infra.Entities;
using SystemService.Service.Interface.Menu;

namespace SystemService.Controllers.Menu
{
    /// <summary>
    /// 窗口管理
    /// </summary>
    [ApiController]
    [Route("api/system/window/[action]")]
    [Authorize]
    public class WindowController : ControllerBase
    {
        private readonly IWindowAppService _windowApp;

        public WindowController(IWindowAppService windowApp)
        {
            _windowApp = windowApp;
        }

        /// <summary>
        /// 根据用户ID查窗口编码列表
        /// </summary>
        [HttpGet("user/{userId}")]
        public async Task<ApiResult<List<string>>> GetWindowsByUserId(long userId)
        {
            var list = await _windowApp.GetWindowsByUserIdAsync(userId);
            return ApiResult<List<string>>.Ok(list);
        }

        /// <summary>
        /// 查询所有窗口列表
        /// </summary>
        [HttpGet]
        public async Task<ApiResult<List<SysWpfWindow>>> GetList()
        {
            var list = await _windowApp.GetListAsync();
            return ApiResult<List<SysWpfWindow>>.Ok(list);
        }

        /// <summary>
        /// 添加窗口
        /// </summary>
        [HttpPost]
        public async Task<ApiResult<long>> Add([FromBody] dynamic body)
        {
            var id = await _windowApp.AddAsync(body.windowCode, body.windowName);
            return ApiResult<long>.Ok(id);
        }

        /// <summary>
        /// 修改窗口
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ApiResult<bool>> Update(long id, [FromBody] dynamic body)
        {
            var result = await _windowApp.UpdateAsync(id, body.windowCode, body.windowName);
            return ApiResult<bool>.Ok(result);
        }

        /// <summary>
        /// 删除窗口
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ApiResult<bool>> Delete(long id)
        {
            var result = await _windowApp.DeleteAsync(id);
            return ApiResult<bool>.Ok(result);
        }
    }
}
