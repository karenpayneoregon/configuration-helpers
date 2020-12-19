using System;
using System.Collections.Generic;
using System.IO;
using ConfigurationHelper.Classes;
using Microsoft.Extensions.Configuration;
using SecurityHelper;
using Environment = ConfigurationHelper.Classes.Environment;

namespace ConfigurationHelper
{
    public class Helper
    {
        private static string _fileName = "appsettings.json";
        /// <summary>
        /// Connection string for application database stored in appsettings.json
        /// Another option would be to have the full connection string in the json file.
        /// </summary>
        /// <returns></returns>
        public static string ConnectionString()
        {

            InitConfiguration();
            var applicationSettings = InitOptions<DatabaseSettings>("database");

            var connectionString =
                $"Data Source={applicationSettings.DatabaseServer};" +
                $"Initial Catalog={applicationSettings.Catalog};" +
                "Integrated Security=True";

            return connectionString;
        }
        
        /// <summary>
        /// Determine if EF logging should be used
        /// </summary>
        /// <returns></returns>
        public static bool UseLogging()
        {
            
            InitConfiguration();
            
            var applicationSettings = InitOptions<ApplicationSettings>("database");

            return applicationSettings.UsingLogging;

        }
        /// <summary>
        /// Get connection string based on environment
        /// </summary>
        public static string GetConnectionString()
        {
            return ConfigurationBuilderRoot()
                .GetConnectionString(InitOptions<Environment>("Environment").Production ?
                    "ProductionConnection" :
                    "DevelopmentConnection");
        }
        /// <summary>
        /// Read encrypted connection string
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionStringSecure()
        {
            return ApplicationConfiguration.Reader(ConfigurationBuilderRoot()
                .GetConnectionString(InitOptions<Environment>("Environment").Production ?
                    "ProductionConnection" :
                    "DevelopmentConnection"));
        }
        /// <summary>
        /// Get connection strings for environments and see if dev or prod is to be used
        /// to connection to a database.
        /// </summary>
        /// <returns></returns>
        public static ConnectionStrings GetSettings()
        {

            try
            {
                InitConfiguration();
                
                var connectionStrings = InitOptions<ConnectionStrings>("ConnectionStrings");
                var environment = InitOptions<Environment>("Environment");

                return new ConnectionStrings()
                {
                    DevelopmentConnection = connectionStrings.DevelopmentConnection,
                    ProductionConnection = connectionStrings.ProductionConnection,
                    IsProduction = environment.Production
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Initialize ConfigurationBuilder
        /// </summary>
        /// <returns>IConfigurationRoot</returns>
        private static IConfigurationRoot InitConfiguration()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(_fileName);

            return builder.Build();

        }
        private static IConfigurationRoot ConfigurationBuilderRoot()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile(_fileName, optional: false);

            var configuration = builder.Build();
            return configuration;
        }
        /// <summary>
        /// Generic method to read a section from the json configuration file.
        /// </summary>
        /// <typeparam name="T">Class type</typeparam>
        /// <param name="section">Section to read</param>
        /// <returns>Instance of T</returns>
        public static T InitOptions<T>(string section) where T : new()
        {
            var config = InitConfiguration();
            return config.GetSection(section).Get<T>();
        }
    }
}
