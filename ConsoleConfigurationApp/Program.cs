using System;
using System.Diagnostics;
using ConsoleConfigurationApp.Classes;
using ConsoleConfigurationApp.Models;

namespace ConsoleConfigurationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SomeModel someModel = new SomeModel();
            someModel.DoSomething();
        }
    }
}
