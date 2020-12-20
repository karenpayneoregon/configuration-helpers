using System.Collections.Generic;
using ConfigurationHelper.Classes;

namespace TableContainerFrontEnd.Classes
{
    /// <summary>
    /// Container for GroupBy in program class
    /// </summary>
    internal class ColumnItemGroup
    {
        /// <summary>
        /// Table name
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// Column definitions for table
        /// </summary>
        public List<TableContainer> Columns { get; set; }
    }
}