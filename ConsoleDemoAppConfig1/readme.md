# About

This is more of a conventional way to work with connection string for different environments.

# Taken from

The following 
[GitHub repository](https://github.com/karenpayneoregon/EntityFramework-environment-connections) for the following TechNet Wiki article[Entity Framework/Entity Framework Core dynamic connection strings (C#)](https://social.technet.microsoft.com/wiki/contents/articles/54079.entity-frameworkentity-framework-core-dynamic-connection-strings-c.aspx) 

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<appSettings>
		<!--
			Here server name is the same for all three, each one would be different for a real application while the database
			would be the same typically but if different change the Initial Catalog as needed
		/>-->
		<add key="DevConnection" value="Data Source=.\SQLEXPRESS;Initial Catalog=School;Integrated Security=True" />
		<add key="StagingConnection" value="Data Source=.\SQLEXPRESS;Initial Catalog=School;Integrated Security=True" />
		<add key="ProductionConnection" value="Data Source=.\SQLEXPRESS;Initial Catalog=School;Integrated Security=True" />
	</appSettings>
</configuration>
```