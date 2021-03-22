# About

Using .NET Framework 4.8 read connection string from appsettings.json and show it works.



![screen](assets/connect.png)

#### appsettings.json

:heavy_check_mark: Change the connection string to match your's

```json
{
  "ConnectionStrings": {
    "DevelopmentConnection": "Server=.\\SQLEXPRESS;Database=School;Integrated Security=true",
    "ProductionConnection": "Server=ProdServerDoesNotExists;Database=School;Integrated Security=true"
  },
  "Environment": {
    "Production": false
  }
}
```

# Test

```csharp
using System;
using System.Data.SqlClient;
using Connections;

namespace ConnectionsFrontEnd.Classes
{
    public class DataOperations
    {
        public static bool TestConnection()
        {
            try
            {
                using (var cn = new SqlConnection() {ConnectionString = Helper.GetConnectionString()})
                {
                    cn.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                /*
                 * Make sure to do logging or some other form
                 * of recovery.
                 */
                return false;
            }
        }
    }
}
```
### Usage

```csharp
MessageBox.Show(DataOperations.TestConnection() ? 
    $"Connected\nIs production connection? {Helper.GetSettings().IsProduction.ToYesNoString()}" : 
    "Connect failed");
```
