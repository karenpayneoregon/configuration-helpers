# Working with multiple environments for connection strings

Demonstrates how to use a class project to get connection strings for Entity Framework Core 5 in non-asp.net core projects e.g. WPF, Console and Windows Forms.

April 2022, see the following [repository](https://github.com/karenpayneoregon/configurations-package) for EF Core 5 [NuGet package](https://www.nuget.org/packages/EntityFrameworkCoreHelpers/) to connect to SQL-Server with various options.

#### Out of the box connection

This is fine for hobbyist coder were the connection never changes while for professional development this method to connection to databases is restrictive in that when moving from development to test to production environment means the connection string must be updated and then rebuild the application for deployment.

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        optionsBuilder.UseSqlServer(
            "Server=.\\SQLEXPRESS;" +
            "Database=NorthWindAzureForInserts;Trusted_Connection=True;");
    }
}
```
Another example for connection environments, production, test, development

```json
{
  "ConnectionStrings": {
    "DevelopmentConnection": "Server=.\\SQLEXPRESS;Database=ocs;Integrated Security=true",
    "ProductionConnection": "Server=.\\PROD;Database=ocs;Integrated Security=true",
    "TestConnection": "Server=.\\TEST;Database=ocs;Integrated Security=true",
    "Environment": 1
  }
}
```

# VB.NET

:gear: The project visualBasicConnectionCodeSample (.NET Core 5) uses the C# connection helper.

# Requires

- Microsoft Visual Studio 2019
- Microsoft SQL-Server (Express edition or better)
- Run schoolScript.sql to generate the database or configure appsettings.json for your database. Best to run against the included database first as it's been tested.

# NuGet packages 

[microsoft.extensions.configuration](https://www.nuget.org/packages/Microsoft.Extensions.Configuration/) <br/>
[microsoft.extensions.configuration.binder](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder/)<br/>
[microsoft.extensions.configuration.FileExensions](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.FileExtensions/)<br/>
[microsoft.extensions.configuration.Json](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json/)

#### Sample appsettings.json 1
```json
{
  "database": {
    "DatabaseServer": ".\\SQLEXPRESS",
    "Catalog": "School",
    "IntegratedSecurity": "true",
    "UsingLogging": "true"
  },
  "ConnectionStrings": {
    "DevelopmentConnection": "Server=.\\SQLEXPRESS;Database=School;Integrated Security=true",
    "ProductionConnection": "Server=ProdServerDoesNotExists;Database=School;Integrated Security=true"
  },
  "Environment": {
    "Production": false
  }
}
```

#### Sample appsettings.json 2

```json
{
  "GeneralSettings": {
    "LogExceptions": true,
    "DatabaseSettings": {
      "DatabaseServer": ".\\SQLEXPRESS",
      "Catalog": "School",
      "IntegratedSecurity": true,
      "UsingLogging": true
    },
    "EmailSettings": {
      "Host": "smtp.gmail.com",
      "Port": 587,
      "EnableSsl": true,
      "DefaultCredentials": false,
      "PickupDirectoryLocation": "MailDrop"
    }
  }
}
```
# Microsoft TechNet article

[.NET Core desktop application configurations](https://social.technet.microsoft.com/wiki/contents/articles/54173.net-core-desktop-application-configurations-c.aspx)

# See also

[Connectionstring.com](https://www.connectionstrings.com/) for various connections string for different providers.

# TechNet 

- [C# Working with SQL-Server connection](https://social.technet.microsoft.com/wiki/contents/articles/53379.c-working-with-sql-server-connection.aspx)
- [Entity Framework/Entity Framework Core dynamic connection strings (C#)](https://social.technet.microsoft.com/wiki/contents/articles/54079.entity-frameworkentity-framework-core-dynamic-connection-strings-c.aspx)

How to setup Entity Framework 6 and Entity Framework Core connections for desktop applications for different environments encrypted and unencrypted connection strings read from app.config

```csharp
namespace EntityFramework6Library
{
 
    using System.Data.Entity;
 
    public partial class NorthWindContext : DbContext
    {
 
#if Dev
        public NorthWindContext() : base("name=DevConnection")
#elif Staging
        public NorthWindContext() : base("name=StagingConnection")
#else
        public NorthWindContext() : base("name=ProductionConnection")
#endif
        { }
 
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
```

