using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AppsettingsFolder.Classes
{
    public static class DirectoryExtensions
    {
        /// <summary>
        /// Given a folder name return all parents according to level
        /// </summary>
        /// <param name="folderName">Sub-folder name</param>
        /// <param name="level">Level to move up the folder chain</param>
        /// <returns>List of folders dependent on level parameter</returns>
        public static string UpperFolder(this string folderName, int level)
        {
            var folderList = new List<string>();

            while (!string.IsNullOrWhiteSpace(folderName))
            {
                var parentFolder = Directory.GetParent(folderName);
                if (parentFolder == null)
                {
                    break;
                }

                folderName = Directory.GetParent(folderName).FullName;
                folderList.Add(folderName);
            }

            if (folderList.Count > 0 && level > 0)
            {
                if (level - 1 <= folderList.Count - 1)
                {
                    return folderList[level - 1];
                }
                else
                {
                    return folderName;
                }
            }
            else
            {
                return folderName;
            }
        }

        public static string CurrentSolutionFolder() => AppDomain.CurrentDomain.BaseDirectory.UpperFolder(5);
        public static string CurrentProjectFolder() => AppDomain.CurrentDomain.BaseDirectory.UpperFolder(4);



    }
}