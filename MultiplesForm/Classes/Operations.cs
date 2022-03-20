using System;
using System.Data.SqlClient;
using static ConfigurationLibrary.Classes.ConfigurationHelper;

namespace MultiplesForm.Classes
{
    public class Operations
    {
        public static bool TestConnection()
        {
            try
            {
                using var cn = new SqlConnection() { ConnectionString = ConnectionString() };
                cn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
