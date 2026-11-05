using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SystemService.Infra.Entities;
using SystemService.Service.Interface.User;

namespace SystemService.Controllers.User
{
    /// <summary>
    /// 后端API资源管理
    /// </summary>
    [ApiController]
    [Route("api/system/apiresource/[action]")]
    [Authorize]
    public class ApiResourceController : ControllerBase
    {
        private readonly IApiResourceAppService _apiApp;

        public ApiResourceController(IApiResourceAppService apiApp)
        {
            _apiApp = apiApp;
        }

        /// <summary>
        /// 查询所有API列表
        /// </summary>
        [HttpGet]
        public async Task<ApiResult<List<SysApiResource>>> GetList()
        {
            var list = await _apiApp.GetListAsync();
            return ApiResult<List<SysApiResource>>.Ok(list);
        }

        /// <summary>
        /// 添加API
        /// </summary>
        [HttpPost]
        public async Task<ApiResult> Add([FromBody] SysApiResource api)
        {
            await _apiApp.AddAsync(api);
            return ApiResult.Ok();
        }

        /// <summary>
        /// 修改API
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ApiResult<bool>> Update(long id, [FromBody] SysApiResource api)
        {
            api.Id = id;
            var result = await _apiApp.UpdateAsync(api);
            return ApiResult<bool>.Ok(result);
        }

        /// <summary>
        /// 删除API
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ApiResult<bool>> Delete(long id)
        {
            var result = await _apiApp.DeleteAsync(id);
            return ApiResult<bool>.Ok(result);
        }
    }
}
