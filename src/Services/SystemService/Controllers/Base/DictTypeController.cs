using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SystemService.Infra.Entities;
using SystemService.Service.Interface.Base;

namespace SystemService.Controllers.Base
{
    /// <summary>
    /// 字典类型表管理
    /// </summary>
    [Route("api/system/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class DictTypeController : ControllerBase
    {
        private readonly IDictTypeAppService _dictTypeApp;

        public DictTypeController(IDictTypeAppService dictTypeApp)
        {
            _dictTypeApp = dictTypeApp;
        }

        /// <summary>
        /// 查询所有字典类型列表
        /// </summary>
        [HttpGet]
        public async Task<ApiResult<List<SysDictType>>> GetList()
        {
            var list = await _dictTypeApp.GetListAsync();
            return ApiResult<List<SysDictType>>.Ok(list);
        }

        /// <summary>
        /// 添加字典类型
        /// </summary>
        [HttpPost]
        public async Task<ApiResult<long>> Add([FromBody] dynamic body)
        {
            var id = await _dictTypeApp.AddAsync(body.name, body.code);
            return ApiResult<long>.Ok(id);
        }

        /// <summary>
        /// 修改字典类型
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ApiResult<bool>> Update(long id, [FromBody] dynamic body)
        {
            var result = await _dictTypeApp.UpdateAsync(id, body.name, body.code);
            return ApiResult<bool>.Ok(result);
        }

        /// <summary>
        /// 删除字典类型
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ApiResult<bool>> Delete(long id)
        {
            var result = await _dictTypeApp.DeleteAsync(id);
            return ApiResult<bool>.Ok(result);
        }

    }
}
