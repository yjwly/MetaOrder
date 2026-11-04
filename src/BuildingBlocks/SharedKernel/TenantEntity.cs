using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel
{
    public class TenantEntity
    {
        /// <summary>
        /// 主键ID（雪花算法）
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, ColumnName = "id")]
        public long Id { get; set; }

        /// <summary>
        /// 租户ID
        /// </summary>
        [SugarColumn(ColumnName = "tenant_id")]
        public long TenantId { get; set; }



        /// <summary>
        /// 创建人
        /// </summary>
        [SugarColumn(ColumnName = "created_by")]
        public long? CreatedBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnName = "created_time")]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        [SugarColumn(ColumnName = "updated_by")]
        public long? UpdatedBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [SugarColumn(ColumnName = "updated_time")]
        public DateTime UpdatedTime { get; set; }

        /// <summary>
        /// 是否删除（软删除）
        /// </summary>
        [SugarColumn(ColumnName = "is_deleted")]
        public bool IsDeleted { get; set; }


    }

    // 公司基类（业务表用）
    public class CompanyEntity : TenantEntity
    {
        public long CompanyId { get; set; }
    }
}
