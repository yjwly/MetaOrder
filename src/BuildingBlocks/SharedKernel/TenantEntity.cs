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
        /// ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long Id { get; set; }
        /// <summary>
        /// 租户Id
        /// </summary>
        public long TenantId { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>
        public long CompanyId { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public long? CreatedBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public long? UpdatedBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdatedTime { get; set; }


        /// <summary>
        /// 是否删除（软删除）
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
