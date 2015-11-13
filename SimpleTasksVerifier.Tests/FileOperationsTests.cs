using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using SimpleTasksVerifier.Helpers;
using SimpleTasksVerifier.FileOperations;

namespace SimpleTasksVerifier.Tests
{
    [TestClass]
    public class FileOperationsTests
    {
        private const string NotEmptyFileName = "SampleNotEmptyFile.txt";
        private const string EmptyFileName = "SampleEmptyFile.txt";

        [TestMethod]
        public void Test_Read_Data_From_File_Not_Empty_File()
        {
            // Arrange
            string result;
            string fileName = NotEmptyFileName;

            // Act 
            result = ReadEmbeddedFileContent(fileName);

            // Assert
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void Test_Read_Data_From_File_Empty_File()
        {
            // Arrange
            string result;
            string fileName = EmptyFileName;

            // Act 
            result = ReadEmbeddedFileContent(fileName);

            // Assert
            Assert.IsTrue(result.Length == 0); 
        }

        private static string ReadEmbeddedFileContent(string fileName)
        {
            string result;
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "SimpleTasksVerifier.Tests." + fileName;

            using (CustomFileReader fileReader = new CustomFileReader(assembly.GetManifestResourceStream(resourceName)))
            {
                var lines = fileReader.ReadFile();
                result = string.Join("\n", lines);
            }
                
            return result;
        }
    }
}
