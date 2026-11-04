using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Shared.Db.Base;
using Shared.Web.Base;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 使用autofac替代默认容器
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// 添加Serilog日志
builder.AddMetaOrderSerilog();

// Add services to the container.
builder.Services.AddControllers(options =>
{
    // 全局异常过滤器
    options.Filters.Add<GlobalExceptionFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "系统服务",
        Version = "v1",
        Description = "系统服务，用户、角色、菜单以及一些基础设置"
    });

    // 加 JWT 认证
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });
    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = new List<string>()
    });
    //  XML 注释
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

// 添加 JWT 认证
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Auth:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Auth:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Auth:SecretKey"]!)),
            ValidateLifetime = true
        };
    });
// 添加 SqlSugar 数据库连接
builder.Services.AddMateOrder(builder.Configuration);

// 添加 redis 缓存
builder.Services.AddMaterOrderRedis(builder.Configuration);

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


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();