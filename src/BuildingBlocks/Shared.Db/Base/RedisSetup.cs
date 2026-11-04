using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Db.Base
{
    /// <summary>
    /// 封装Redis
    /// </summary>
    public static class RedisSetup
    {
        public static IServiceCollection AddMaterOrderRedis(this IServiceCollection services,IConfiguration cfg)
        {
            services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                return ConnectionMultiplexer.Connect(cfg["Redis:ConnString"]!);
            });
            services.AddScoped<IRedisService, RedisService>();
            return services;
        }
    }
}
