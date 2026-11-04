using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SystemService.Infra.Entities;
using SystemService.Service.Interface.Base;

namespace SystemService.Controllers.Base
{
    /// <summary>
    /// 字典表管理
    /// </summary>
    [Route("api/[controller]/[action]")]
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
    }
}
