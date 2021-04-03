using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using static System.Configuration.ConfigurationManager;

namespace ConsoleDemoAppConfig2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConventionFrameworkMethod();

            Console.ReadLine();
        }
        /// <summary>
        /// For .NET Core
        /// </summary>
        private static void CoreMethod()
        {
            using SqlConnection cn = new(AppSettings["DevConnection"]);

            try
            {
                cn.Open();
                Console.WriteLine("Open");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// For .NET Core asynchronous
        /// </summary>
        private static async Task CoreMethodTask()
        {
            await using SqlConnection cn = new(AppSettings["DevConnection"]);

            try
            {
                await cn.OpenAsync();
                Console.WriteLine("Open");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// For conventional .NET Framework 4.8 and below
        /// </summary>
        private static void ConventionFrameworkMethod()
        {
            using SqlConnection cn = new(AppSettings["DevConnection"]);
            {
                try
                {
                    cn.Open();
                    Console.WriteLine("Open");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
