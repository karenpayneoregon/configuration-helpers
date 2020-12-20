# About 

:green_square: Example for appsettings.json to store database settings and email settings.

## Usage
```csharp
var configuration = Helper.Configuration();
```

### appsettings.json
```json
{
  "GeneralSettings": {
    "LogExceptions": false,
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
