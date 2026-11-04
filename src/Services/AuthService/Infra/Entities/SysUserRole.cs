using SqlSugar;

namespace AuthService.Infra.Entities
{
    /// <summary>
    /// 用户-角色关联表
    /// </summary>
    [SugarTable("sys_user_role")]
    public class SysUserRole
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleId { get; set; }
    }
}
