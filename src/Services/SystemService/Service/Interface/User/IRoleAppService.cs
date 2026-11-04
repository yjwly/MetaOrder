using SharedKernel;
using SystemService.Infra.Dtos.User;
using SystemService.Infra.Entities;
using SystemService.Infra.QueryDtos.User;

namespace SystemService.Service.Interface.User
{
    public interface IRoleAppService
    {
        /// <summary>
        /// 获取角色列表
        /// </summary>
        Task<PagedResult<SysRole>> GetListAsync(RoleQueryDto dto);

        /// <summary>
        /// 获取角色详情
        /// </summary>
        Task<SysRole> GetByIdAsync(long id);

        /// <summary>
        /// 添加角色
        /// </summary>
        Task<long> AddAsync(RoleCreateDto dto);

        /// <summary>
        /// 修改角色
        /// </summary>
        Task UpdateAsync(long id, RoleCreateDto dto);

        /// <summary>
        /// 删除角色
        /// </summary>
        Task DeleteAsync(long id);
    }
}
