# About

Simple example for obtaining connection strings.

Get current connection by `ActiveEnvironment`

```csharp
ConnectionString()
```

Get connection string by environment name, in this case development.

```csharp
ConfigurationMap map = Connections();
map.Development
```

**appsettings.json**

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

![image](assets/Versions.png)

