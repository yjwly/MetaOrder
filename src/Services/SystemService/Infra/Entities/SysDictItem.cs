using SharedKernel;
using SqlSugar;

namespace SystemService.Infra.Entities
{
    /// <summary>
    /// 字典项表
    /// </summary>
    [SugarTable("sys_dict_item")]
    public class SysDictItem : TenantEntity
    {
        /// <summary>字典类型ID</summary>
        [SugarColumn(ColumnName = "dict_type_id")]
        public long DictTypeId { get; set; }

        /// <summary>字典项标签</summary>
        [SugarColumn(ColumnName = "label")]
        public string Label { get; set; } = "";

        /// <summary>字典项值</summary>
        [SugarColumn(ColumnName = "value")]
        public string Value { get; set; } = "";

        /// <summary>排序</summary>
        [SugarColumn(ColumnName = "sort")]
        public int Sort { get; set; } = 0;
    }
}
