using SharedKernel;
using SqlSugar;

namespace SystemService.Infra.Entities
{
    /// <summary>
    /// 角色表
    /// </summary>
    [SugarTable("sys_role")]
    public class SysRole : TenantEntity
    {
        /// <summary>角色编码</summary>
        [SugarColumn(ColumnName = "code")]
        public string Code { get; set; } = "";

        /// <summary>角色名称</summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; } = "";

        /// <summary>数据范围：1全部 2本公司及子 3本公司 4本部门 5自定义</summary>
        [SugarColumn(ColumnName = "data_scope")]
        public int DataScope { get; set; } = 3;

        /// <summary>备注</summary>
        [SugarColumn(ColumnName = "remark")]
        public string? Remark { get; set; }
    }
}
