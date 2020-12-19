using System;
using System.Linq;
using EntityLibrary.Data;
using static ConsoleHelpers.ConsoleColors;

namespace ConsoleDemoAppConfig1
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
            WriteSectionYellow(nameof(StandardConnection));

            SchoolContext context = new();
            var people = context.Person.ToList();

            Console.WriteLine($"People count : {people.Count}");

        }


    }
}