using System;
using System.Diagnostics;
using System.Linq;
using EntityLibrary.Data;
using static ConsoleHelpers.ConsoleColors;

namespace ConsoleDemoApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardConnection();
            Console.ReadLine();
        }

        static void StandardConnection()
        {
            WriteSection(nameof(StandardConnection));
            
            SchoolContext context = new();
            var people = context.Person.ToList();
            
            Console.WriteLine($"People count : {people.Count}");

        }


    }
}
