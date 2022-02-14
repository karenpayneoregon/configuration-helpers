using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleConfigurationApp.Classes;

namespace ConsoleConfigurationApp.Models
{
    public class SomeModel
    {
        public int  Id { get; set; }
        public void DoSomething()
        {
            Example result = Helper.Example();
            Debug.WriteLine(result.SomeProperty);
        }
    }
}
