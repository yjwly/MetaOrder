using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SystemService.Infra.Dtos.User;
using SystemService.Infra.Entities;
using SystemService.Infra.QueryDtos.User;
using SystemService.Service.Interface.User;

namespace SystemService.Controllers.Role;

/// <summary>
/// 角色管理
/// </summary>
[ApiController]
[Route("api/system/[controller]/[action]")]
[Authorize]
public class RoleController : ControllerBase
{
    private readonly IRoleAppService _roleApp;

    public RoleController(IRoleAppService roleApp)
    {
        _roleApp = roleApp;
    }

    /// <summary>
    /// 获取角色列表
    /// </summary>
    [HttpGet]
    public async Task<ApiResult<PagedResult<SysRole>>> GetList([FromQuery] RoleQueryDto dto)
    {
        var result = await _roleApp.GetListAsync(dto);
        return ApiResult<PagedResult<SysRole>>.Ok(result);
    }

    /// <summary>
    /// 获取角色详情
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ApiResult<SysRole>> GetById(long id)
    {
        var role = await _roleApp.GetByIdAsync(id);
        return ApiResult<SysRole>.Ok(role!);
    }

    /// <summary>
    /// 添加角色
    /// </summary>
    [HttpPost]
    public async Task<ApiResult<long>> Add([FromBody] RoleCreateDto dto)
    {
        var id = await _roleApp.AddAsync(dto);
        return ApiResult<long>.Ok(id);
    }

    /// <summary>
    /// 修改角色
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ApiResult> Update(long id, [FromBody] RoleCreateDto dto)
    {
        await _roleApp.UpdateAsync(id, dto);
        return ApiResult.Ok();
    }

    /// <summary>
    /// 删除角色
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ApiResult> Delete(long id)
    {
        await _roleApp.DeleteAsync(id);
        return ApiResult.Ok();
    }
}
