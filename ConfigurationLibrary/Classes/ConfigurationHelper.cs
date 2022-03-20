using System;
using Microsoft.Extensions.Configuration;

namespace ConfigurationLibrary.Classes
{
    public class ConfigurationHelper
    {

        public static ConnectionsConfiguration CurrentEnvironment { get; private set; }
        /// <summary>
        /// Current connection string by 'ActiveEnvironment'
        /// </summary>
        /// <returns>Connection string</returns>
        public static string ConnectionString()
        {
            var configuration = Builder();
            ConfigurationMap map = configuration.GetSection("ConnectionsConfiguration").Get<ConfigurationMap>();
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
        /// <summary>
        /// Get all environment connection strings
        /// </summary>
        /// <returns><see cref="ConfigurationMap"/></returns>
        public static ConfigurationMap Connections()
        {
            var configuration = Builder();
            return configuration.GetSection("ConnectionsConfiguration").Get<ConfigurationMap>();
        }

        private static IConfigurationRoot Builder()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            return configuration;
        }
    }
}
