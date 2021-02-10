# MyFramework v1.0.0
MyFramework 是 Asp.NetCore 小型项目快速开发框架。目前对数据仓储，工作单元，数据审计， Services，dto，公共方法进行了简单的封装，尽可能达到能快速开发，又不失灵活性。

书店后台管理系统 demo: https://github.com/niaiaiai/BookStoreDemo

书店后台管理系统前端 demo: https://github.com/niaiaiai/BookStoreDemoWeb

demo: https://studydemo.online:8081/

## 用命令行创建项目模板
    dotnet new -i MyFramework.Templates --nuget-source http://studydemo.online:13564/v3/index.json
    dotnet new Myfw -n [项目名称]

## 项目结构
ddd 架构

* Application 应用层
* Domain 领域层
* Infrastructure 基础设施层
* Web web 层
* Ids4 IdentityServer4 认证授权服务器，可单独部署

* ApplicationTest 应用层测试项目
* DomainTest 领域层测试项目
* InfrastructureTest 基础设施层测试项目
* WebTest web 层测试项目
* TestBase 测试项目的基类

* docker-compose Web 项目的 docker 编排文件
* Web/Dockerfile 生成 docker 镜像
* nuget.config nuget 仓库设置

## 数据库迁移
实现 IDataSeed 接口后，会自动迁移并初始化数据。

Package Manager 命令:
```
PM> Add-Migration Init -Context XXXContext -Project Infrastructure -StartupProject Infrastructure -Args '--environment Development'
PM> Update-Database -Context XXXContext -Project Infrastructure -StartupProject Infrastructure -Args '--environment Development'
```

环境参数的依据是项目中配置文件，如:
```
-Args '--environment Development' 或 -Args '--environment Production'
```

## 包含的项目
个人 baget 仓库地址: http://studydemo.online:13564/

* Utils                  公共类，公共方法
* MyServices             Service 的封装    注入常用的接口，封装分页dto
* MyRepositories         仓储及工作单元     可自动提交事务，仓储参考abp
* MyEntityFrameworkCore  DbContext 基类    封装了软删除和数据审计的功能
* MyEntity               实体基类，数据审计 包括创建、更新数据的审计，软删除
* MyAuthorization        IdentityServer4 的 web 项目 暂时未使用

## 第三方依赖
* AutoMapper
* IdentityServer4

## 项目维护
现在框架处于初始阶段，以后会坚持维护，完善框架。