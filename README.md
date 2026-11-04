# 元序 MetaOrder

> ERP + MES 一体化系统，面向中小制造企业的数字化解决方案。

## 项目简介

元序 MetaOrder 是一个多租户 ERP + MES 一体化系统，覆盖从采购、销售、库存到生产工单、报工、质检的全流程业务。

- **多租户**：一套系统服务多个企业，数据隔离
- **微服务**：按业务拆分成独立服务，可独立部署
- **多端覆盖**：Web ERP + WPF 桌面 MES + uni-app 移动端

## 技术栈

### 后端
- **.NET 8** - 运行时
- **ASP.NET Core** - Web API 框架
- **Autofac** - 依赖注入容器
- **SqlSugar** - ORM 框架
- **MySQL** - 主数据库
- **Redis** - 缓存 / 分布式锁
- **RabbitMQ** - 消息队列
- **Serilog** - 日志框架
- **JWT + OAuth2** - 认证授权
- **YARP** - API 网关
- **Consul** - 服务注册发现

### 前端
- **Vue 3 + TypeScript** - Web ERP 前端
- **WPF + DevExpress** - 桌面 MES 客户端
- **uni-app** - 移动端报工 / 巡检

## 项目结构
## 项目结构

- **src/** - 源代码
  - **BuildingBlocks/** - 共享基础设施
    - SharedKernel - 枚举、基类、接口
    - Shared.Db - SqlSugar封装、Redis、工作单元
    - Shared.Web - Serilog、Swagger配置
    - Shared.Mq - RabbitMQ封装
    - Shared.Clients - Refit跨服务调用
  - **Services/** - 业务服务
    - AuthService - 认证服务 :5001
    - SystemService - 系统管理 :5002
    - ErpService - ERP业务 :5100
    - MesService - MES生产 :5200
  - **Gateways/** - 网关
    - WebGateway - YARP网关 :8080
- **web-erp/** - Vue3 Web前端
- **desktop-mes/** - WPF桌面端
- **mobile-app/** - uni-app移动端


## 核心功能

### ERP 模块
- 采购管理：采购申请 → 采购订单 → 到货入库
- 销售管理：销售报价 → 销售订单 → 发货出库
- 库存管理：实时库存、库存预警、盘点
- 财务管理：应收应付、成本核算

### MES 模块
- 生产工单：工单下达、派工、领料
- 报工管理：移动端扫码报工、完工上报
- 质量管理：来料检验、过程检验、成品检验
- 设备管理：设备台账、维保记录、OEE分析

### 系统管理
- 多租户：租户开通、套餐管理、数据隔离
- 用户权限：用户、角色、菜单、按钮级权限
- 组织架构：集团 → 公司 → 工厂 → 车间 → 仓库
- 数据字典：基础数据可配置化

## 快速开始

### 环境要求
- .NET 8 SDK
- MySQL 8.0+
- Redis 6.0+
- RabbitMQ 3.8+
- Node.js 20+

### 后端启动
```bash
# 1. 还原NuGet包
dotnet restore

# 2. 启动数据库迁移
# 执行 init-database.sql 创建表

# 3. 启动服务（每个服务单独一个终端）
cd src/Services/AuthService
dotnet run

cd src/Services/SystemService
dotnet run
#部署
┌─────────┐     ┌─────────┐
│  Nginx  │────▶│  YARP   │  网关
└─────────┘     └─────────┘
                      │
        ┌───────┬───────┼───────┬───────┐
        ▼       ▼       ▼       ▼       ▼
    AuthSvc  SysSvc  ErpSvc  MesSvc  WGW
        │       │       │       │
        └───────┴───┬───┴───────┘
                    ▼
              ┌─────────┐
              │ MySQL   │  主库
              │ Redis   │  缓存
              │ RabbitMQ│  消息
              └─────────┘


