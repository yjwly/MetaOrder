using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Helper
{
    /// <summary>
    /// 业务操作日志帮助类
    /// </summary>
    public class AuditLogHelper
    {
        private readonly ISqlSugarClient _db;

        public AuditLogHelper(ISqlSugarClient db)
        {
            _db = db;
        }

        /// <summary>
        /// 写操作日志
        /// </summary>
        public async Task LogAsync(long userId, string module, string action, string requestUrl, string requestParam, string ip)
        {
            await _db.Ado.ExecuteCommandAsync(
                    @"INSERT INTO sys_audit_log (id, tenant_id, user_id, module, action, request_url, request_param, ip, created_time) 
          VALUES (@id, 0, @userId, @module, @action, @requestUrl, @requestParam, @ip, NOW())",
                    new { id = Guid.NewGuid().ToString(), userId, module, action, requestUrl, requestParam, ip });
        }
    }
}
