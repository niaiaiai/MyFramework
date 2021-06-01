# MyFramework v1.0.0
MyFramework is an open source framework for small scale development. Simply encapsulated UnitOfWork, repositories, audit, services, DTOs and some public methods, readable and easily scale.

demo system: https://github.com/niaiaiai/BookStoreDemo

demo system frontend: https://github.com/niaiaiai/BookStoreDemoWeb

demo: https://studydemo.online:8081/

## Getting Started
    dotnet new -i MyFramework.Templates --nuget-source http://studydemo.online:13564/v3/index.json
    dotnet new Myfw -n [your project name]

## Project Structure
Domain-driven design (DDD)

* Ids4 IdentityServer4  Authentication and authorization service, can be separately deploy with the project.
* ApplicationTest       Test project for application layer.
* DomainTest            Test project for domain model layer.
* InfrastructureTest    Test project for infrastructure layer.
* WebTest               Test project for web layer.
* TestBase              A base project for all the test projects.

* docker-compose  Docker compose file.
* Web/Dockerfile  A Dockerfile for building the docker image.
* nuget.config    Settings for your own nuget repositories.

## Migration
Will be initialize/migrate automatically after implement the IDataSeed interface. 

Package Manager Command:
```
PM> Add-Migration Init -Context XXXContext -Project Infrastructure -StartupProject Infrastructure -Args '--environment Development'
PM> Update-Database -Context XXXContext -Project Infrastructure -StartupProject Infrastructure -Args '--environment Development'
```

The arguements should be the enviromnent used in the appsettings file, for example:
```
-Args '--environment Development' or -Args '--environment Production'
```

## Included Projects
private baget repository address: http://studydemo.online:13564/

* Utils                  Some common classes and methods.
* MyServices             Encapsulation of services, encapsulated some interfaces and pagination DTOs.
* MyRepositories         UnitOfWork and repositories, allow commit transcation automatically.
* MyEntityFrameworkCore  DbContext base clase, encapsulated soft delete and audit.
* MyEntity               Base class of all the entity. Audit, including create, update, and soft delete.
* MyAuthorization        Not in use yet.

## Third Party Dependencies
* AutoMapper
* IdentityServer4

## About Maintance
The framework is now and will keep maintaining to improve.