using System;
using static System.Console;

namespace ConsoleHelpers
{
    public static class ConsoleColors
    {
        public static void WriteSection(string message)
        {
            var originalForeColor = ForegroundColor;

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine(message);
            ForegroundColor = originalForeColor;
            WriteLine(new string('-',100));
        }
    }
}
