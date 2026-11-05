using SqlSugar;

namespace SystemService.Infra.Entities
{
    /// <summary>
    /// 角色权限关联表
    /// </summary>
    [SugarTable("sys_role_permission")]
    public class SysRolePermission
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [SugarColumn(ColumnName = "id")]
        public long Id { get; set; }

        /// <summary>
        /// 租户ID
        /// </summary>
        [SugarColumn(ColumnName = "tenant_id")]
        public long TenantId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        [SugarColumn(ColumnName = "role_id")]
        public long RoleId { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        [SugarColumn(ColumnName = "menu_id")]
        public long MenuId { get; set; }

        /// <summary>
        /// 按钮ID
        /// </summary>
        [SugarColumn(ColumnName = "button_id")]
        public long ButtonId { get; set; }
    }
}
