using System;

namespace ConsoleAppNotCore.Classes
{
    public class Demos
    {
        public static void Run()
        {
            Operations result1 = Helpers.GetObject<Operations>();
            Console.WriteLine(result1.Name());

            FileOperations result2 = Helpers.GetObject<FileOperations>();
            Console.WriteLine(result2.Path);
        }
    }
}