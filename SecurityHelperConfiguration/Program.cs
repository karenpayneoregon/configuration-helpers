using System;
using SecurityHelper;

namespace SecurityHelperConfiguration
{
    class Program
    {
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
