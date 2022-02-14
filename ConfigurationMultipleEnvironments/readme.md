# Working with multiple environments for connection strings

This project demonstrates how to obtain a database connection string from either reading `appsettings.json` or from reading an `environment variable` for working with desktop apps and minor change for web apps.

When reading from json, the section `ConnectionsConfiguration` has a property `ActiveEnvironment` which indicates which environment to use. In code, there is an `enum` shown in figure 2 which matches properties in appsettings.json.

When reading an environment variable make sure the variable is defined like `ASPNETCORE_ENVIRONMENT` or a custom environment variable, otherwise the code will throw an exception. See code in figure 3.

To try out each version see figure 5 in a console project.

**Note** that `Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");` allows you to simulate an environment rather than constantly changing that evironment variable.

**Figure 1**

```json
{
  "ConnectionsConfiguration": {
    "ActiveEnvironment": "Production",
    "Development": "Dev connection string goes here",
    "Stage": "Stage connection string goes here",
    "Production": "Prod connection string goes here"
  }
}
```

**Figure 2**

```csharp
public class ConfigurationMap
{
    public string ActiveEnvironment { get; set; }
    public string Development { get; set; }
    public string Stage { get; set; }
    public string Production { get; set; }
}
```

**Figure 3**

```csharp
public static string GetConnectionStringFromJson()
{
    var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
    var configuration = builder.Build();
    var map = configuration.GetSection("ConnectionsConfiguration").Get<ConfigurationMap>();
    ConnectionsConfiguration environment = map.ActiveEnvironment
        .ToEnum(ConnectionsConfiguration.Development);

    CurrentEnvironment = environment;

    return environment switch
    {
        ConnectionsConfiguration.Development => map.Development,
        ConnectionsConfiguration.Stage => map.Stage,
        ConnectionsConfiguration.Production => map.Production,
        _ => map.Development
    };

}

```

**Figure 4**

```csharp
public static string GetConnectionStringFrom_Environment()
{
    var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables();
    var configuration = builder.Build();
    var map = configuration.GetSection("ConnectionsConfiguration").Get<ConfigurationMap>();

    /*
     * We can use ASPNETCORE_ENVIRONMENT or OED_ENVIRONMENT
     */
    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToEnum(ConnectionsConfiguration.Development);
    

    CurrentEnvironment = environment;

    return environment switch
    {
        ConnectionsConfiguration.Development => map.Development,
        ConnectionsConfiguration.Stage => map.Stage,
        ConnectionsConfiguration.Production => map.Production,
        _ => map.Development
    };

}

```

**Figure 5**

```csharp
class Program
{
    
    static void Main(string[] args)
    {

        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");

        Console.Title = "Connection strings from json or environment var";

        Debug.WriteLine($"Json: {ConfigurationHelper.GetConnectionStringFromJson()}");
        Debug.WriteLine($"{ConfigurationHelper.CurrentEnvironment}");
        
        Debug.WriteLine("");

        Debug.WriteLine($"Environment: {ConfigurationHelper.GetConnectionStringFrom_Environment()}");
        Debug.WriteLine($"{ConfigurationHelper.CurrentEnvironment}");
    }
}
```

# Requires

- Visual Studio 2019 or higher
- .NET Core 5 SDK or higher
- Several NuGet packages are used, Visual Studio should perform a restore and if not you need to perform the restore.