using SimpleTasksVerifier.FileOperations;
using SimpleTasksVerifier.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

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

            CustomFileStreamReader fileStreamReader = new CustomFileStreamReader(folder, fileName);
            SafeFileReader reader = new SafeFileReader(fileStreamReader);

            return reader.ReadFile(); 
        }
    }
}
