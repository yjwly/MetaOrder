using SqlSugar;

namespace SystemService.Infra.Entities
{
    /// <summary>
    /// 角色菜单关联表
    /// </summary>
    [SugarTable("sys_role_permission")]
    public class SysRoleMenu
    {
        /// <summary>角色ID</summary>
        [SugarColumn(ColumnName = "role_id")]
        public long RoleId { get; set; }

        /// <summary>菜单ID</summary>
        [SugarColumn(ColumnName = "menu_id")]
        public long MenuId { get; set; }
    }
}
