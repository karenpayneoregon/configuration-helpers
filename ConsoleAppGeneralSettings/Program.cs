using System;
using System.IO;
using ConfigurationHelper;
using static ConsoleHelpers.ConsoleColors;
namespace ConsoleAppGeneralSettings
{
    class Program
    {
        static void Main(string[] args)
        {
            
            WriteHeader("General settings");
            
            var configuration = Helper.Configuration();

            WriteSectionBold("Connection string", false);
            WriteIndented(configuration.DatabaseSettings.ConnectionString);

            WriteSectionBold("LogExceptions", false);
            WriteIndented(configuration.LogExceptions);

            WriteSectionBold("Email host", false);
            WriteIndented(configuration.EmailSettings.Host);

            WriteSectionBold("Email port", false);
            WriteIndented(configuration.EmailSettings.Port);

            WriteSectionBold("DefaultCredentials", false);
            WriteIndented(configuration.EmailSettings.DefaultCredentials);
            
            WriteSectionBold("EnableSsl", false);
            WriteIndented(configuration.EmailSettings.EnableSsl);

            WriteSectionBold("PickupDirectoryLocation", false);
            WriteIndented(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configuration.EmailSettings.PickupDirectoryLocation));

            Console.ReadKey();
        }
    }
}
