using System.Collections.Generic;
using ConfigurationHelper.Classes;

namespace TableContainerFrontEnd.Classes
{
    internal class ColumnItemGroup
    {
        public string TableName { get; set; }
        public List<TableContainer> Columns { get; set; }
    }
}