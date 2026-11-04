using Microsoft.AspNetCore.Builder;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Web.Base
{
    public static class SerilogSetup
    {
        public static void AddMetaOrderSerilog(this WebApplicationBuilder builder)
        {
            var logPath = Path.Combine(AppContext.BaseDirectory, "logs", builder.Environment.ApplicationName);

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", builder.Environment.ApplicationName)
                // 写所有级别日志到控制台
                .WriteTo.Console()
                // 写所有级别日志到文件
                .WriteTo.File(
                    path: Path.Combine(logPath, ".txt"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 30)
               // 只写 Warning 及以上级别到数据库（log_db.sys_system_log）
               .WriteTo.MySQL(
                connectionString: builder.Configuration["LogDb:ConnString"]!,
                tableName: "sys_system_log_" + DateTime.Now.ToString("yyyyMM"),  // 表名带月份
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning)
                .CreateLogger();

            builder.Host.UseSerilog();
        }
    }
}
