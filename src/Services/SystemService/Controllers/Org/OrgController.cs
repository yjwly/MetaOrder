using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SystemService.Infra.Entities;
using SystemService.Service.Interface.Org;

namespace SystemService.Controllers.Org
{
    /// <summary>
    /// 组织管理
    /// </summary>
    [ApiController]
    [Route("api/system/org/[action]")]
    [Authorize]
    public class OrgController : ControllerBase
    {
        private readonly IOrgAppService _orgApp;

        public OrgController(IOrgAppService orgApp)
        {
            _orgApp = orgApp;
        }

        /// <summary>
        /// 查询所有组织列表
        /// </summary>
        [HttpGet]
        public async Task<ApiResult<List<SysOrg>>> GetList()
        {
            var list = await _orgApp.GetListAsync();
            return ApiResult<List<SysOrg>>.Ok(list);
        }

        /// <summary>
        /// 添加组织
        /// </summary>
        [HttpPost]
        public async Task<ApiResult<long>> Add([FromBody] dynamic body)
        {
            var id = await _orgApp.AddAsync(body.name, body.code, body.parentId, body.sort);
            return ApiResult<long>.Ok(id);
        }

        /// <summary>
        /// 修改组织
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ApiResult<bool>> Update(long id, [FromBody] dynamic body)
        {
            var result = await _orgApp.UpdateAsync(id, body.name, body.code, body.parentId, body.sort);
            return ApiResult<bool>.Ok(result);
        }

        /// <summary>
        /// 删除组织
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ApiResult<bool>> Delete(long id)
        {
            var result = await _orgApp.DeleteAsync(id);
            return ApiResult<bool>.Ok(result);
        }
    }
}
