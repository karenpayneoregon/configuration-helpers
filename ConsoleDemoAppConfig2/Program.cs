using System;
using System.Data.SqlClient;
using static System.Configuration.ConfigurationManager;

namespace ConsoleDemoAppConfig2
{
    class Program
    {
        static void Main(string[] args)
        {

            using var cn = new SqlConnection(AppSettings["DevConnection"]);
            cn.Open();
            Console.WriteLine("Open");
            Console.ReadLine();
        }
    }
}
