using SqlSugar;

namespace SystemService.Infra.Entities
{
    /// <summary>
    /// 角色窗口关联表
    /// </summary>
    [SugarTable("sys_role_window")]
    public class SysRoleWindow
    {
        /// <summary>角色ID</summary>
        [SugarColumn(ColumnName = "role_id")]
        public long RoleId { get; set; }

        /// <summary>窗口编码</summary>
        [SugarColumn(ColumnName = "window_code")]
        public string WindowCode { get; set; } = "";
    }
}
