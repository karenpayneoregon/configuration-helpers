using System;
using System.Configuration;
using System.IO;
using static System.Configuration.ConfigurationManager;

namespace ConsoleAppNotCore.Classes
{
    public class ApplicationSettings
    {
        public static void SetFileLocation(string fileName) => SetValue("file_location", fileName);
        public static string GetFileLocation => AppSettings["file_location"];
        public static void SetValue(string key, string value)
        {

            var appName = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location);

            var configFile = Path.Combine(appName, 
                $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.exe.config");

            var configFileMap = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
            var config = OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            if (config.AppSettings.Settings[key] == null)
            {
                throw new Exception($"Key {key} does not exist");
            }

            config.AppSettings.Settings[key].Value = value;

            config.Save();

            RefreshSection("appSettings");

        }
    }
}