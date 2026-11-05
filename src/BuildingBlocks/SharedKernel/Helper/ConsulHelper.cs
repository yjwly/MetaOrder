using Consul;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Helper
{
    /// <summary>
    /// Consul 帮助类
    /// </summary>
    public static class ConsulHelper
    {
        /// <summary>
        /// 注册服务到 Consul
        /// </summary>
        public static async Task RegisterConsul(this IHost host, string serviceName, int port)
        {
            var config = host.Services.GetRequiredService<IConfiguration>();
            var consulAddress = config["Consul:Address"] ?? "http://localhost:8500";

            var client = new ConsulClient(c => c.Address = new Uri(consulAddress));

            var serviceId = $"{serviceName}-{Guid.NewGuid()}";

            // 注册服务
            await client.Agent.ServiceRegister(new AgentServiceRegistration
            {
                ID = serviceId,
                Name = serviceName,
                Address = "localhost",
                Port = port,
                Check = new AgentServiceCheck
                {
                    HTTP = $"http://localhost:{port}/health",
                    Interval = TimeSpan.FromSeconds(10),
                    Timeout = TimeSpan.FromSeconds(5)
                }
            });

            Console.WriteLine($"服务 {serviceName} 已注册到 Consul");
        }

        /// <summary>
        /// 从 Consul 注销服务
        /// </summary>
        public static async Task DeregisterConsul(this IHost host, string serviceName)
        {
            var config = host.Services.GetRequiredService<IConfiguration>();
            var consulAddress = config["Consul:Address"] ?? "http://localhost:8500";

            var client = new ConsulClient(c => c.Address = new Uri(consulAddress));

            // 注销所有该服务的实例
            var services = await client.Agent.Services();
            foreach (var service in services.Response.Values.Where(x => x.Service == serviceName))
            {
                await client.Agent.ServiceDeregister(service.ID);
            }

            Console.WriteLine($"服务 {serviceName} 已从 Consul 注销");
        }
    }
}
