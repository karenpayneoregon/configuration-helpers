using System;
using AppsettingsFolder.Classes;

namespace AppsettingsFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper.Initializer();
            Console.WriteLine($"{Helper.Environment.ToString()} = {Helper.ConnectionString}");
            Console.ReadLine();
        }
    }
}
