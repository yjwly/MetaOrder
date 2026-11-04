using SystemService.Infra.Dtos.Base;
using SystemService.Infra.Dtos.User;

namespace SystemService.Service.Interface.User
{
    /// <summary>
    /// 用户角色服务
    /// </summary>
    public interface IUserRoleAppService
    {
        /// <summary>
        /// 根据用户ID查角色ID列表
        /// </summary>
        Task<List<long>> GetRoleIdsByUserIdAsync(long userId);

        /// <summary>
        /// 分配角色
        /// </summary>
        Task AssignRolesAsync(UserRoleDto dto);

        /// <summary>
        /// 用户角色树
        /// </summary>
        Task<List<TreeNodeDto>> GetUserRoleTreeAsync();
    }
}
