using SharedKernel;
using SqlSugar;

namespace SystemService.Infra.Entities
{
    /// <summary>
    /// 组织表
    /// </summary>
    [SugarTable("sys_org")]
    public class SysOrg : TenantEntity
    {
        /// <summary>父级ID</summary>
        [SugarColumn(ColumnName = "parent_id")]
        public long ParentId { get; set; }

        /// <summary>组织名称</summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; } = "";

        /// <summary>组织编码</summary>
        [SugarColumn(ColumnName = "code")]
        public string Code { get; set; } = "";

        /// <summary>排序</summary>
        [SugarColumn(ColumnName = "sort")]
        public int Sort { get; set; } = 0;
    }
}
