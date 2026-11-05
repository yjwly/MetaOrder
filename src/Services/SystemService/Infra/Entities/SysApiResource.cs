using SharedKernel;
using SqlSugar;

namespace SystemService.Infra.Entities
{
    /// <summary>
    /// 后端API资源表
    /// </summary>
    [SugarTable("sys_api_resource")]
    public class SysApiResource 
    {
        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(ColumnName = "id")]
        public long Id { get; set; }
        /// <summary>
        /// 租户ID
        /// </summary>

        [SugarColumn(ColumnName = "tenant_id")]
        public long TenantId { get; set; }
        /// <summary>
        /// 路由模式
        /// </summary>
        [SugarColumn(ColumnName = "route_pattern")]
        public string RoutePattern { get; set; } = "";

        /// <summary>
        /// 请求方式
        /// </summary>
        [SugarColumn(ColumnName = "http_method")]
        public string HttpMethod { get; set; } = "*";

        /// <summary>
        /// 权限编码
        /// </summary>
        [SugarColumn(ColumnName = "perm_code")]
        public string? PermCode { get; set; }

        /// <summary>
        /// 是否需要租户
        /// </summary>
        [SugarColumn(ColumnName = "require_tenant")]
        public int RequireTenant { get; set; } = 1;
    }
}
