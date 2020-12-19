using System;
using System.Diagnostics;
using System.Linq;
using EntityLibrary.Data;
using static ConsoleHelpers.ConsoleColors;

namespace ConsoleDemoApp1
{
    /// <summary>
    /// Demonstrate secure and insecure connection strings. Both code samples
    /// need attention before running in regards to comments in each method.
    /// </summary>
    /// <remarks>
    /// Secure connection strings can be created as per done in SecurityHelperConfiguration
    /// project, of course code could be written for a proper user interface if so desired.
    /// </remarks>
    class Program
    {
        static void Main(string[] args)
        {
            StandardConnection();
            Console.ReadLine();
        }
        /// <summary>
        /// Use insecure connection string
        /// </summary>
        /// <remarks>
        /// In appsettings.json set ConnectionStrings.DevelopmentConnection to
        /// Server=.\\SQLEXPRESS;Database=School;Integrated Security=true
        /// </remarks>
        private static void StandardConnection()
        {
            WriteSection(nameof(StandardConnection));
            
            SchoolContext context = new();
            var people = context.Person.ToList();
            
            Console.WriteLine($"People count : {people.Count}");

        }
        /// <summary>
        /// Use an encrypted connection
        /// </summary>
        /// <remarks>
        /// In appsettings.json set ConnectionStrings.DevelopmentConnection to
        /// bQ3FJ8OaAQM5XVQ2iGMQfsn+b1dGsCXyov+iLDCRgtO3tU/lLwVKgpfKshQj+9muOD0pwgcKoOKyl1uWNg/0vg==
        /// </remarks>
        private static void SecureConnection()
        {
            WriteSection(nameof(SecureConnection));

            SchoolContextSecure context = new();
            var people = context.Person.ToList();

            Console.WriteLine($"People count : {people.Count}");

        }

    }
}
