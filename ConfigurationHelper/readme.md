# About

Contains help methods to configure a DbContext connection, environment and logging read from appsettings.json in a project.

Although C# 9 is used (configured in each project file) the majority of code will work with lower versions of C# while the recommendation is to use C# 9.

@octocat :+1: This PR looks great - it's ready to merge! :shipit:

|Scope|Method/property   |Definition   |
| :---         |  :---  | :--- |
|private|ConfigurationFileName (P)   |Configuration file in frontend project   |
|public|ConnectionString (M)   | Used to get one connection string (no environent)   |
|public|UseLogging (M)   |true to use logging, false no logging   |
|public|GetSettings   |Get all connection string with environment   |
|public|GetConnectionString (M)   |Get prod or dev connection string insecure   |
|public|GetConnectionStringSecure (M)   |Get prod or dev connection string secure   |
|private|InitMainConfiguration (M)  |Initialize ConfigurationBuilder for appsettings.json   |
|private|InitColumnsConfiguration (M)  |Initialize ConfigurationBuilder for columnsettings.json   |
|private|ConfigurationBuilderRoot (M)   |Configuration building   |
|public|InitOptions (M)  |Generic method to read section in configuration file   |

# Requires
- Microsoft Visual Studio 2019
- Microsoft SQL-Server (minimum Express edition)
- Microsoft SSMS (SQL-Server Management Studio) which is optional for creating the database which can be done in Visual Studio also.

# NuGet packages 

[microsoft.extensions.configuration](https://www.nuget.org/packages/Microsoft.Extensions.Configuration/) <br/>
[microsoft.extensions.configuration.binder](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder/)<br/>
[microsoft.extensions.configuration.FileExensions](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.FileExtensions/)<br/>
[microsoft.extensions.configuration.Json](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json/)
