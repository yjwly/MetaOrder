using SharedKernel;
using SqlSugar;

namespace SystemService.Infra.Entities
{
    /// <summary>
    /// 菜单表（路由权限）
    /// </summary>
    [SugarTable("sys_menu")]
    public class SysMenu : TenantEntity
    {
        /// <summary>父级ID</summary>
        [SugarColumn(ColumnName = "parent_id")]
        public long ParentId { get; set; }

        /// <summary>菜单名称</summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; } = "";

        /// <summary>菜单URL</summary>
        [SugarColumn(ColumnName = "url")]
        public string? Url { get; set; }

        /// <summary>菜单图标</summary>
        [SugarColumn(ColumnName = "icon")]
        public string? Icon { get; set; }

        /// <summary>排序</summary>
        [SugarColumn(ColumnName = "sort")]
        public int Sort { get; set; } = 0;
    }
}
