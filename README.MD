### What is Zero Slope? ###
ZeroSlope is a .net core micro-service scaffold with adoption and simplicity in mind. This project is meant to provide a simple and lean architecture using common industry technologies and practices. All dependencies are constructed and stored in a IoC container following the Composition Root pattern. API Documentation is auto-generated using a Swagger front-end.

This implementation focuses on a Sql Server back-end using Dapper to persist.

### Technologies ###
* .Net 6
* Sql Server 2012-2019, Azure Sql PaaS, PostgresSQL
* Docker *(Optional)*
* Redis Cache *(Optional)*


### Features ###
* Global Error Handling
* Authentication
* Authorization
* Composition Root IoC
* Dapper + Contrib Micro-ORM
* Redis Caching


### Architecture ###

Coming soon.


### Solution Structure ###
```
├─── 📁 Documentation
│   
├─── 📁 Infrastructure
│   ├─── #️ ZeroSlope.Composition
│   └─── #️ ZeroSlope.Infrastructure
│   
├─── 📁 Testing
│   ├─── #️ ZeroSlope.Api.Tests
│   └─── #️ ZeroSlope.Domain.Tests
│   
├─── 🗃️ ZeroSlope.Database
│   ├─── 📁 Scripts
│   └─── 📁 Schemas
│   
├─── #️ ZeroSlope.Models
│   └─── 📁 Authentication
│        ├─── 📁 Requests
│        └─── 📁 Responses
│   
├─── #️ ZeroSlope.Domain
│   ├─── 📁 Base
│   ├─── 📁 Entities
│   ├─── 📁 Mappers
│   └─── 📁 Services
│   
└─── #️ ZeroSlope.Api
    ├─── 📁 Controllers
    ├─── 📁 Middleware
    ├─── 📄 appsettings.json
    ├─── 📄 Dockerfile
    ├─── 📄 Program.cs
    └─── 📄 Usings.cs
```


### How do I get set up? ###
* Windows
	* Open Visual studio, and click the `Play` button.
* Unix / MacOSX
	* Open bash in the root of the solution, and use the command `dotnet restore` and then `dotnet run`


### Sql Server in Docker?
Simply run the following ...
```
docker run 
	-d --name zeroslope-db 
	--env "ACCEPT_EULA=Y" 
	--env "MSSQL_SA_PASSWORD=P4ssw0rd!" 
	--env "SA_PASSWORD=P4ssw0rd!" 
	--env "MSSQL_PID=Developer" 
	-p 1401:1433 
	-d mcr.microsoft.com/mssql/server:2019-latest
```


### Redis in Docker?
Simply run the following ...
```
docker run 
	-d --name zeroslope-redis 
	-p 6379:6379
	-d redis
```


### How do I deploy? ###
Coming soon.


### Configuration ###
Coming soon.


### Getting Started ###
Coming soon.


### Examples ###
Coming soon.

