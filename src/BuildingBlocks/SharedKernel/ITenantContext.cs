using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel
{

    public interface ITenantContext
    {
        /// <summary>
        /// 租户Id
        /// </summary>
        long TenantId { get; }
        /// <summary>
        /// 公司Id
        /// </summary>
        long CompanyId { get; }

        /// <summary>
        /// 用户编号
        /// </summary>
        long UserId { get; }

        /// <summary>
        /// 用户名称
        /// </summary>
        string UserName { get; }
    }
}
