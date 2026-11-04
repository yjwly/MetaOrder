using SharedKernel;
using SqlSugar;

namespace SystemService.Infra.Entities
{
    /// <summary>
    /// 按钮表
    /// </summary>
    [SugarTable("sys_button")]
    public class SysButton : TenantEntity
    {
        /// <summary>菜单ID</summary>
        [SugarColumn(ColumnName = "menu_id")]
        public long MenuId { get; set; }

        /// <summary>按钮名称</summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; } = "";

        /// <summary>按钮编码</summary>
        [SugarColumn(ColumnName = "code")]
        public string Code { get; set; } = "";
    }
}
