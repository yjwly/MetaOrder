using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SystemService.Infra.Dtos.User;
using SystemService.Infra.Entities;
using SystemService.Infra.QueryDtos.User;
using SystemService.Service.Interface.User;

namespace SystemService.Controllers.User;

/// <summary>
/// 用户管理
/// </summary>
[ApiController]
[Route("api/system/User/[action]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserAppService _userApp;

    public UserController(IUserAppService userApp)
    {
        _userApp = userApp;
    }

    /// <summary>
    /// 获取用户列表
    /// </summary>
    [HttpGet]
    public async Task<ApiResult<PagedResult<SysUser>>> GetList([FromQuery] UserQueryDto dto)
    {
        var result = await _userApp.GetListAsync(dto);
        return ApiResult<PagedResult<SysUser>>.Ok(result);
    }

    /// <summary>
    /// 获取用户详情
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ApiResult<SysUser>> GetById(long id)
    {
        var user = await _userApp.GetByIdAsync(id);
        return ApiResult<SysUser>.Ok(user!);
    }

    /// <summary>
    /// 添加用户
    /// </summary>
    [HttpPost]
    public async Task<ApiResult<long>> Add([FromBody] UserCreateDto dto)
    {
        var id = await _userApp.AddAsync(dto);
        return ApiResult<long>.Ok(id);
    }

    /// <summary>
    /// 修改用户
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ApiResult> Update(long id, [FromBody] UserCreateDto dto)
    {
        await _userApp.UpdateAsync(id, dto);
        return ApiResult.Ok();
    }

    /// <summary>
    /// 删除用户
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ApiResult> Delete(long id)
    {
        await _userApp.DeleteAsync(id);
        return ApiResult.Ok();
    }
}
