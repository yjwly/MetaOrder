using SharedKernel;
using SqlSugar;

namespace SystemService.Infra.Entities
{
    /// <summary>
    /// 字典类型表
    /// </summary>
    [SugarTable("sys_dict_type")]
    public class SysDictType : TenantEntity
    {
        /// <summary>字典名称</summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; } = "";

        /// <summary>字典编码</summary>
        [SugarColumn(ColumnName = "code")]
        public string Code { get; set; } = "";
    }
}
