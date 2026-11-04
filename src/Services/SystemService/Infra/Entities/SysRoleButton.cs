using SqlSugar;

namespace SystemService.Infra.Entities
{
    /// <summary>
    /// 角色按钮关联表
    /// </summary>
    [SugarTable("sys_role_button")]
    public class SysRoleButton
    {
        /// <summary>角色ID</summary>
        [SugarColumn(ColumnName = "role_id")]
        public long RoleId { get; set; }

        /// <summary>按钮ID</summary>
        [SugarColumn(ColumnName = "button_id")]
        public long ButtonId { get; set; }
    }
}
