using Microsoft.Extensions.Configuration;

namespace ConsoleConfigurationApp.Classes
{
    public class Helper
    {
        
        public static string ConfigurationFileName { get; set; } = "appsettings.json";
        public static Example Example()
        {
            var config = InitMainConfiguration();
            return config.GetSection("Section1").Get<Example>();
        }
        private static IConfigurationRoot InitMainConfiguration()
        {

            var builder = new ConfigurationBuilder()
                // change the path to where ever the json file resides
                .SetBasePath("C:\\OED")
                .AddJsonFile(ConfigurationFileName);
            return builder.Build();
        }
    }
}
