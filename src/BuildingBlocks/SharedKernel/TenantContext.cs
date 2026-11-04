using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace SharedKernel
{
    /// <summary>
    /// 创建租户上下文
    /// </summary>
    public class TenantContext : ITenantContext
    {
        private readonly IHttpContextAccessor _accessor;

        public TenantContext(IHttpContextAccessor accessor) => _accessor=accessor;

        /// <summary>
        /// 租户Id
        /// </summary>
        public long TenantId =>long.Parse( _accessor.HttpContext?.User.FindFirst("tenant_id")?.Value??"0");

        /// <summary>
        /// 公司Id
        /// </summary>
        public long CompanyId => long.Parse(_accessor.HttpContext?.User.FindFirst("company_id")?.Value??"0");

        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId => long.Parse(_accessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value??"0");

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName => _accessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value??"";
    }
}
