using System;
using AppsettingsFolder.Classes;

namespace AppsettingsFolder
{
    class Program
    {
        static void Main(string[] args)
        {


            Example();

            Console.ReadLine();
        }

        private static void Example()
        {
            Helper.Initializer();
            Console.WriteLine($"{Helper.Environment} = {Helper.ConnectionString}");
            Console.ReadLine();
        }
    }
}
