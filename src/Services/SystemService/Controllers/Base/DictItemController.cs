using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SystemService.Infra.Dtos.Base;
using SystemService.Infra.Entities;
using SystemService.Service.Interface.Base;

namespace SystemService.Controllers.Base
{
    /// <summary>
    /// 字典项管理
    /// </summary>
    [ApiController]
    [Route("api/system/dictitem/[action]")]
    [Authorize]
    public class DictItemController : ControllerBase
    {
        private readonly IDictItemAppService _dictItemApp;

        public DictItemController(IDictItemAppService dictItemApp)
        {
            _dictItemApp = dictItemApp;
        }

        /// <summary>
        /// 根据字典类型ID查字典项列表
        /// </summary>
        [HttpGet("dicttype/{dictTypeId}")]
        public async Task<ApiResult<List<SysDictItem>>> GetListByDictTypeId(long dictTypeId)
        {
            var list = await _dictItemApp.GetListByDictTypeIdAsync(dictTypeId);
            return ApiResult<List<SysDictItem>>.Ok(list);
        }

        /// <summary>
        /// 根据字典类型编码查字典项列表
        /// </summary>
        [HttpGet("code/{dictTypeCode}")]
        public async Task<ApiResult<List<SysDictItem>>> GetListByDictTypeCode(string dictTypeCode)
        {
            var list = await _dictItemApp.GetListByDictTypeCodeAsync(dictTypeCode);
            return ApiResult<List<SysDictItem>>.Ok(list);
        }
        /// <summary>
        /// 生成字典树
        /// </summary>
        [HttpGet("tree")]
        public async Task<ApiResult<List<DictTreeDto>>> GetDictTree()
        {
            var tree = await _dictItemApp.GetDictTreeAsync();
            return ApiResult<List<DictTreeDto>>.Ok(tree);
        }

        /// <summary>
        /// 添加字典项
        /// </summary>
        [HttpPost]
        public async Task<ApiResult<long>> Add([FromBody] dynamic body)
        {
            var id = await _dictItemApp.AddAsync(body.dictTypeId, body.label, body.value, body.sort);
            return ApiResult<long>.Ok(id);
        }

        /// <summary>
        /// 修改字典项
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ApiResult<bool>> Update(long id, [FromBody] dynamic body)
        {
            var result = await _dictItemApp.UpdateAsync(id, body.label, body.value, body.sort);
            return ApiResult<bool>.Ok(result);
        }

        /// <summary>
        /// 删除字典项
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ApiResult<bool>> Delete(long id)
        {
            var result = await _dictItemApp.DeleteAsync(id);
            return ApiResult<bool>.Ok(result);
        }


    }
}
