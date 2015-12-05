﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTasksVerifier.Helpers
{
    /// <summary>
    /// Helper class for files operations
    /// </summary>
    public class FileHelper
    {
        public static bool CheckIfFileExists(string path, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return false;

            if (string.IsNullOrEmpty(path))
                return false; 

            return File.Exists(string.Format("{0}\\{1}", path, fileName));
        }

        public static string GetSampleDataFile()
        {
            string fileName = "SampleDataFile.txt";
            return GetApplicationDataFolder() + $"\\{fileName}";
        }

        private static string GetApplicationDataFolder()
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            return $"{appDataFolder}\\{Consts.Application.ApplicationName}";
        }
    }
}
