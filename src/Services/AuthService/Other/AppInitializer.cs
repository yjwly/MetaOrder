using AuthService.Infra.Entities;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System.Reflection;

namespace AuthService.Other
{
    /// <summary>
    /// 启动初始化
    /// </summary>
    public class AppInitializer
    {
        private readonly ISqlSugarClient _db;

        public AppInitializer(ISqlSugarClient db)
        {
            _db = db;
        }

        /// <summary>
        /// 自动扫描Controller，注册API资源
        /// </summary>
        public async Task InitApiResourcesAsync()
        {
            // 扫描所有Controller
            var controllers = typeof(AppInitializer).Assembly
                .GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract && x.Name.EndsWith("Controller"));

            foreach (var controller in controllers)
            {
                //// 查Controller上的路由
                //var routeAttr = controller.GetCustomAttributes(typeof(RouteAttribute))
                //    .FirstOrDefault() as RouteAttribute;

                //var basePath = routeAttr?.Template ?? "";
                //basePath = "/" + basePath.Replace("[controller]", controller.Name.Replace("Controller", ""));

                var methods = controller.GetMethods()
                    .Where(m => m.CustomAttributes.Any(a =>
                        a.AttributeType == typeof(HttpGetAttribute)
                        || a.AttributeType == typeof(HttpPostAttribute)
                        || a.AttributeType == typeof(HttpPutAttribute)
                        || a.AttributeType == typeof(HttpDeleteAttribute)));

                foreach (var method in methods)
                {

                    // 查Controller上的路由
                    var routeAttr = controller.GetCustomAttributes(typeof(RouteAttribute))
                        .FirstOrDefault() as RouteAttribute;

                    var basePath = routeAttr?.Template ?? "";
                    basePath = "/" + basePath
                        .Replace("[controller]", controller.Name.Replace("Controller", ""))
                        .Replace("[action]", method.Name);
                    // 查HTTP方法
                    var httpMethod = "GET";
                    var methodTemplate = "";

                    if (method.GetCustomAttributes(typeof(HttpPostAttribute)).Any())
                    {
                        httpMethod = "POST";
                        var attr = method.GetCustomAttributes(typeof(HttpPostAttribute)).FirstOrDefault() as HttpPostAttribute;
                        methodTemplate = attr?.Template ?? "";
                    }
                    else if (method.GetCustomAttributes(typeof(HttpPutAttribute)).Any())
                    {
                        httpMethod = "PUT";
                        var attr = method.GetCustomAttributes(typeof(HttpPutAttribute)).FirstOrDefault() as HttpPutAttribute;
                        methodTemplate = attr?.Template ?? "";
                    }
                    else if (method.GetCustomAttributes(typeof(HttpDeleteAttribute)).Any())
                    {
                        httpMethod = "DELETE";
                        var attr = method.GetCustomAttributes(typeof(HttpDeleteAttribute)).FirstOrDefault() as HttpDeleteAttribute;
                        methodTemplate = attr?.Template ?? "";
                    }
                    else
                    {
                        var attr = method.GetCustomAttributes(typeof(HttpGetAttribute)).FirstOrDefault() as HttpGetAttribute;
                        methodTemplate = attr?.Template ?? "";
                    }

                    // 拼完整路径
                    var path = basePath;
                    if (!string.IsNullOrEmpty(methodTemplate))
                    {
                        path += "/" + methodTemplate;
                    }
                    // 把 {xxx} 去掉
                    path = System.Text.RegularExpressions.Regex.Replace(path, @"/\{[^}]*\}", "");


                    // 查是否已经存在
                    var exist = await _db.Queryable<SysApiResource>()
                        .Where(x => x.RoutePattern == path && x.HttpMethod == httpMethod)
                        .AnyAsync();

                    if (!exist)
                    {
                        // 添加
                        var api = new SysApiResource
                        {
                            Id = SnowFlakeSingle.instance.getID(),
                            RoutePattern = path,
                            HttpMethod = httpMethod,
                        };
                        await _db.Insertable(api).ExecuteCommandAsync();
                    }
                }
            }
        }
    }
}
