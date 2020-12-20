using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConfigurationHelper;
using TableContainerFrontEnd.Classes;

using static ConsoleHelpers.ConsoleColors;

namespace TableContainerFrontEnd
{
    class Program
    {
        private static string _fileName = "columnsettings.json";
        static void Main(string[] args)
        {

            WriteHeader("Table columns");
            Helper.ConfigurationFileName = "columnsettings.json";
            var results = Helper.ColumnTableContainers()
                .GroupBy(tc => tc.Name)
                .Select((@group) => new ColumnItemGroup {TableName = @group.Key, Columns = @group.ToList()});

            foreach (var columnItemGroup in results)
            {

                WriteSectionBold(columnItemGroup.TableName, false);
                
                foreach (var tableContainer in columnItemGroup.Columns)
                {
                    Console.WriteLine($"\t{tableContainer.Column}, {tableContainer.Ordinal}, {tableContainer.Visible}, {tableContainer.DisplayText}");
                }
            }

            Console.ReadLine();
        }

    }
}
