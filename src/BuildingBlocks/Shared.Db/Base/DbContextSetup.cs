using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using SharedKernel;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Db.Base
{
    /// <summary>
    /// SQLsugar封装
    /// </summary>
    public static class DbContextSetup
    {
        /// <summary>
        /// Sqlsuagar连接
        /// </summary>
        /// <param name="services"></param>
        /// <param name="cfg"></param>
        /// <returns></returns>
        public static IServiceCollection AddMateOrder(this IServiceCollection services,IConfiguration cfg)
        {
            services.AddScoped<ISqlSugarClient>(sp =>
            {
                var db = new SqlSugarScope(new ConnectionConfig
                {
                    DbType=DbType.MySql,
                    ConnectionString=cfg["Db:Default:ConnString"],
                    IsAutoCloseConnection=true,
                });
                return db;

            });
            return services;
        }


        /// <summary>
        /// 租户过滤器
        /// </summary>
        public class TeantFilterMiddleware
        {

            /// <summary>
            /// 获取删除请求实例
            /// </summary>
            private readonly RequestDelegate _next;
            public TeantFilterMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task InvokeAsync(HttpContext ctx,ISqlSugarClient db,ITenantContext tc)
            {
                db.QueryFilter.AddTableFilter<TenantEntity>(x =>
                    x.TenantId == tc.TenantId);
                db.QueryFilter.AddTableFilter<TenantEntity>(x =>
                    x.CompanyId == tc.CompanyId);
                db.QueryFilter.AddTableFilter<TenantEntity>(x =>
                    x.IsDeleted == false);

                await _next(ctx);
            }

        }
    }
}
