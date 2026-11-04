using SystemService.Infra.Entities;

namespace SystemService.Infra.Dtos.User
{
    public class UserRoleDto
    {
        /// <summary>用户ID</summary>
        public long UserId { get; set; }

        /// <summary>角色ID列表</summary>
        public List<long> RoleIds { get; set; } = new();
    }
}
