# Rss feed aggregator
## Features
* Configurable list of RSS feed's
* Multi-thread feed fetching
* Async pull and display of all configured RSS feed items

---
## WORK IN PROGRESS
* search logic
* filter logic
* feed tracking
* multi-threading
* FluentAPI integration
* unit tests

---
### Dotnet CLI command used for project and packages handling
* Create project: ```dotnet new webapi -n RssFeedAggregator```
* Build project: ```dotnet build```
* Run project: ```dotnet run```
* Run specific project in solution: ```dotnet run <projectName>```
* Add test framework MSTest: ```dotnet add package MSTest.TestFramework --version 2.1.1```
* Add project reference for testing to test project (P2P): ```dotnet add reference <reference_project_path>```
* Run tests: ```dotnet test```
* Add database migration: ```dotnet ef migrations add <migration_name>```
* Update database using migration: ```dotnet ef database update```

### Required packages:
* EntityFrameworkCore: ```dotnet add package Microsoft.EntityFrameworkCore```
* EntityFrameworkCore.SqlServer: ```dotnet add package Microsoft.EntityFrameworkCore.SqlServer```
* EntityFrameworkCore.Design: ```dotnet add package Microsoft.EntityFrameworkCore.Design```

---
README.md syntax: mark down