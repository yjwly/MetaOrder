using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Shared.Db.Base;
using Shared.Web;
using System.Reflection;
using static Shared.Db.Base.DbContextSetup;

var builder = WebApplication.CreateBuilder(args);

//使用autofac替代默认容器
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
//添加Serilog日志
builder.AddMetaOrderSerilog();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//配置swagger文档
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title="权限认证服务",
        Version="v1",
        Description="用户登录、Token 签发、权限校验",
    });
    //  XML 注释
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});
//拿当前用户登录
builder.Services.AddHttpContextAccessor();

//添加 SqlSugar 数据库连接（存用户、角色、菜单）
builder.Services.AddMateOrder(builder.Configuration);
//添加 JWT 认证
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["Auth:Issuer"];
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Auth:Issuer"],
            ValidateAudience = false,
            ValidateLifetime = true
        };
    });
builder.Services.AddAuthorization();

// 配置 Autofac 自动注册
builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    // 自动注册所有以 AppService / Repository 结尾的类
    container.RegisterAssemblyTypes(typeof(Program).Assembly)
        .Where(t => t.Name.EndsWith("Service") || t.Name.EndsWith("Repository"))
        .AsSelf()
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

// 租户过滤器中间件
app.UseMiddleware<TeantFilterMiddleware>();

app.MapControllers();

app.Run();
