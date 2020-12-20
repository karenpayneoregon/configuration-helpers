# About

Contains help methods to configure a DbContext connection, environment and logging read from appsettings.json in a project.

Although C# 9 is used (configured in each project file) the majority of code will work with lower versions of C# while the recommendation is to use C# 9.

|Scope|Method/property   |Definition   |
| :---         |  :---  | :--- |
|private|_fileName   |Configuration file in frontend project   |
|public|ConnectionString   | Used to get one connection string (no environent)   |
|public|UseLogging   |true to use logging, false no logging   |
|public|GetSettings   |Get all connection string with environment   |
|public|GetConnectionString   |Get prod or dev connection string insecure   |
|public|GetConnectionStringSecure   |Get prod or dev connection string secure   |
|private|InitMainConfiguration   |Initialize ConfigurationBuilder for appsettings.json   |
|private|InitColumnsConfiguration   |Initialize ConfigurationBuilder for columnsettings.json   |
|private|ConfigurationBuilderRoot   |Configuration building   |
|public|InitOptions   |Generic method to read section in configuration file   |

# Requires
- Microsoft Visual Studio 2019
- Microsoft SQL-Server (minimum Express edition)
- Microsoft SSMS (SQL-Server Management Studio) which is optional for creating the database which can be done in Visual Studio also.

# NuGet packages 

[microsoft.extensions.configuration](https://www.nuget.org/packages/Microsoft.Extensions.Configuration/) <br/>
[microsoft.extensions.configuration.binder](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder/)<br/>
[microsoft.extensions.configuration.FileExensions](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.FileExtensions/)<br/>
[microsoft.extensions.configuration.Json](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json/)
