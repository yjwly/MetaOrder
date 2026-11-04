using SqlSugar;

namespace SystemService.Infra.Entities
{
    /// <summary>
    /// 用户-角色关联表
    /// </summary>
    [SugarTable("sys_user_role")]
    public class SysUserRole
    {
        /// <summary>用户ID</summary>
        [SugarColumn(ColumnName = "user_id")]
        public long UserId { get; set; }

        /// <summary>角色ID</summary>
        [SugarColumn(ColumnName = "role_id")]
        public long RoleId { get; set; }
    }
}
