using System;
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

        public static bool CheckIfFileExists(string pathToFile)
        {
            if (string.IsNullOrEmpty(pathToFile))
                return false;

            return File.Exists(pathToFile);
        }

        public static string GetSampleDataFilePath()
        {
            string fileName = "SampleDataFile.txt";
            return GetApplicationDataFolder() + $"\\{fileName}";
        }

        public static string GetApplicationDataFolder()
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            return $"{appDataFolder}\\{Consts.Application.ApplicationName}";
        }
    }
}
