# About

Demonstrates how to use json file for connections.

# Configuration file 

**appsettings.json**

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