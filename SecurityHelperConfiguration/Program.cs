using System;
using SecurityHelper;

namespace SecurityHelperConfiguration
{
    class Program
    {
        /// <summary>
        /// Example to create encrypted connection string for, in this case sql-server
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            var plainText = "Server=.\\SQLEXPRESS;Database=School;Integrated Security=true";
            Console.WriteLine($"Original: {plainText}");
            
            var encryptedText = ApplicationConfiguration.Writer(plainText);
            Console.WriteLine($"Encrypted: {encryptedText}");
            
            var connectionString = ApplicationConfiguration.Reader(encryptedText);
            Console.WriteLine($"Connection string: {connectionString}");
            
            Console.ReadLine();
        }
    }
}
