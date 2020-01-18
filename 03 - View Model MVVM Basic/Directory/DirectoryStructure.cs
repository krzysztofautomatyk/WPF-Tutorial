using _03___View_Model_MVVM_Basic.Directory.Data;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using System.Windows.Controls;

namespace _03___View_Model_MVVM_Basic
{
    public static class DirectoryStructure
    {
        /// <summary>
        /// Gets all logicalo dirves on the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            // Get every logical drive on the machine
           return System.IO.Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
        }

        /// <summary>
        /// Gets the directories top-level content
        /// </summary>
        /// <param name="fullPath">The full path to the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            // Create empty list
            var items = new List<DirectoryItem>();

            #region Get Folders
            

            // Try and get directories from the folder
            // ignoring any issues doing so
            try
            {
                var dirs = System.IO.Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
            }
            catch 
            {

            }
           

            #endregion

            #region Get Files

            // Try and get files from the folder
            // ignoring any issues doing so
            try
            {
                var fs = System.IO.Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    items.AddRange(fs.Select(file => new DirectoryItem { FullPath = file, Type =DirectoryItemType.File }));
            }
            catch
            {
 
            }

            return items;
            #endregion

        }

        #region Helpers

        /// <summary>
        /// Find the file or folder name from a full path
        /// </summary>
        /// <param name="path">the full path</param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            // If we have no path, retun empty
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            // Make all slashes back slashes
            var normalizePath = path.Replace('/', '\\');

            // Find the last backslash in the path
            var lastIndex = normalizePath.LastIndexOf('\\');

            // If we don't find a backslash, return the path itself
            if (lastIndex <= 0)
                return path;

            // Return the name after the last back slash
            return path.Substring(lastIndex + 1);
        }
        #endregion
    }
}
