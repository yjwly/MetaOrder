using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SqlSugar;
using SystemService.Infra.Entities;
using SystemService.Service.Interface.User;

namespace SystemService.Controllers.User
{
    /// <summary>
    /// 租户管理
    /// </summary>
    [ApiController]
    [Route("api/system/tenant")]
    [Authorize]
    public class TenantController : ControllerBase
    {
        private readonly ITenantAppService _tenantApp;

        public TenantController(ITenantAppService tenantApp)
        {
            _tenantApp = tenantApp;
        }

        /// <summary>
        /// 查询所有租户列表
        /// </summary>
        [HttpGet]
        public async Task<ApiResult<List<SysTenant>>> GetList()
        {
            var list = await _tenantApp.GetListAsync();
            return ApiResult<List<SysTenant>>.Ok(list);
        }
        /// <summary>
        /// 添加租户
        /// </summary>
        [HttpPost]
        public async Task<ApiResult> Add([FromBody] SysTenant tenant)
        {
            tenant.Id = SnowFlakeSingle.instance.getID();
            await _tenantApp.AddAsync(tenant);
            return ApiResult.Ok();
        }


        /// <summary>
        /// 修改租户
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ApiResult<bool>> Update(long id, [FromBody] SysTenant tenant)
        {
            tenant.Id = id;
            var result = await _tenantApp.UpdateAsync(tenant);
            return ApiResult<bool>.Ok(result);
        }
        /// <summary>
        /// 删除租户
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ApiResult<bool>> Delete(long id)
        {
            var result = await _tenantApp.DeleteAsync(id);
            return ApiResult<bool>.Ok(result);
        }

    }
}
