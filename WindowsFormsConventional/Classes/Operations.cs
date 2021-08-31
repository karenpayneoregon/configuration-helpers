using System;
using System.Data;
using System.Data.SqlClient;
using static System.Configuration.ConfigurationManager;

//Some may need this
//using System.Collections.Specialized;

namespace WindowsFormsConventional.Classes
{
    public class Operations
    {
        /// <summary>
        /// Test connection
        /// </summary>
        /// <returns></returns>
        public static (bool success, Exception exception) TestConnection()
        {
            try
            {
                using (var cn = new SqlConnection() { ConnectionString = AppSettings["ConnectionString"] })
                {
                    cn.Open();

                    return (true, null);
                }
            }
            catch (Exception exception)
            {
                return (false, exception);
            }
        }
        
        /// <summary>
        /// Simple read joined tables
        /// </summary>
        /// <returns></returns>
        public static (DataTable dataTable, Exception exception) GetCourses()
        {
            DataTable table = new DataTable();
            
            var selectStatement = 
                "SELECT C.CourseID, C.Title, C.Credits, C.DepartmentID, D.Name FROM Course AS C " + 
                "INNER JOIN Department AS D ON C.DepartmentID = D.DepartmentID";
            
            using (var cn = new SqlConnection() {ConnectionString = AppSettings["ConnectionString"]})
            {
                using (var cmd = new SqlCommand() { Connection = cn, CommandText = selectStatement })
                {
                    cn.Open();
                    try
                    {
                        table.Load(cmd.ExecuteReader());
                        table.Columns["CourseID"].ColumnMapping = MappingType.Hidden;
                        table.Columns["DepartmentID"].ColumnMapping = MappingType.Hidden;
                        return (table, null);
                    }
                    catch (Exception exception)
                    {
                        return (table, exception);
                    }
                }
            }
        }
    }
}
