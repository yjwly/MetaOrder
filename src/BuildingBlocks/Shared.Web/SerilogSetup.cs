using Microsoft.AspNetCore.Builder;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Web
{
    public static class SerilogSetup
    {
        public static void AddMetaOrderSerilog(this WebApplicationBuilder builder)
        {
            var logPath = Path.Combine(AppContext.BaseDirectory, "logs", builder.Environment.ApplicationName);
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", builder.Environment.ApplicationName)
                .WriteTo.Console()
                .WriteTo.File(
                    path: Path.Combine(logPath, ".txt"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 30)
                .CreateLogger();

            builder.Host.UseSerilog();
        }
    }
}
