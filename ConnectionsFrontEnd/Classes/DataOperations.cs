using System;
using System.Data.SqlClient;
using Connections;

namespace ConnectionsFrontEnd.Classes
{
    public class DataOperations
    {
        public static bool TestConnection()
        {
            try
            {
                using (var cn = new SqlConnection() {ConnectionString = Helper.GetConnectionString()})
                {
                    cn.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                /*
                 * Make sure to do logging or some other form
                 * of recovery.
                 */
                return false;
            }
        }
    }
}
