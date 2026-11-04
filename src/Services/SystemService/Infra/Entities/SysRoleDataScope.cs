using SqlSugar;

namespace SystemService.Infra.Entities
{
    /// <summary>
    /// 角色数据范围表
    /// </summary>
    [SugarTable("sys_role_data_scope")]
    public class SysRoleDataScope
    {
        /// <summary>角色ID</summary>
        [SugarColumn(ColumnName = "role_id")]
        public long RoleId { get; set; }

        /// <summary>
        /// 公司ID
        /// </summary>
        [SugarColumn(ColumnName = "company_id")]
        public long CompanyId { get; set; }
    }
}
