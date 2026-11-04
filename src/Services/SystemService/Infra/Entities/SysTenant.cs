using SqlSugar;

namespace SystemService.Infra.Entities
{
    /// <summary>
    /// 租户表
    /// </summary>
    [SugarTable("sys_tenant")]
    public class SysTenant
    {
        /// <summary>租户ID</summary>
        [SugarColumn(ColumnName = "id")]
        public long Id { get; set; }

        /// <summary>租户名称</summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; } = "";

        /// <summary>租户编码</summary>
        [SugarColumn(ColumnName = "code")]
        public string Code { get; set; } = "";
    }
}
