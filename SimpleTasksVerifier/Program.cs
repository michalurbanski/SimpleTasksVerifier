using SimpleTasksVerifier.FileOperations;
using SimpleTasksVerifier.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTasksVerifier
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting program...");

            IEnumerable<string> fileContent = ReadFileContentFromApplicationFolder();
            Console.WriteLine("File has been read");
            Console.WriteLine($"File has {fileContent.Count()} lines");

            Console.WriteLine("Program execution finished");
        }

        static IEnumerable<string> ReadFileContentFromApplicationFolder()
        {
            string folder = FileHelper.GetApplicationDataFolder();
            string fileName = "SampleDataFile.txt";

            if (FileHelper.CheckIfFileExists(folder, fileName))
            {
                var fileReader = new CustomFileStreamReader($"{folder}\\{fileName}");
                return fileReader.ReadFile();
            }

            throw new InvalidOperationException($"File {fileName} does not exist");
        }
    }
}
