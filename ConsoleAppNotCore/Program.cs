using System;

namespace ConsoleAppNotCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var current = ApplicationSettings.GetFileLocation;
            Console.WriteLine($"Current path: {current}");
            ApplicationSettings.SetFileLocation(current == "C:\\users\\test\\desktop\\file.csv" ? 
                "C:\\users\\test\\desktop\\file_location.csv" : 
                "C:\\users\\test\\desktop\\file.csv");

            Console.WriteLine($"Current path after set: {ApplicationSettings.GetFileLocation}");

            Console.ReadLine();
        }
    }
}
