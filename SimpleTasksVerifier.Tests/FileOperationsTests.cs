using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace SimpleTasksVerifier.Tests
{
    [TestClass]
    public class FileOperationsTests
    {
        [TestMethod]
        public void Test_Read_Data_From_File_Not_Empty_File()
        {
            // Arrange
            string result;
            string fileName = "SampleNotEmptyFile.txt";

            // Act 
            result = ReadFileContent(fileName);

            // Assert
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void Test_Read_Data_From_File_Empty_File()
        {
            // Arrange
            string result;
            string fileName = "SampleEmptyFile.txt";

            // Act 
            result = ReadFileContent(fileName);

            // Assert
            Assert.IsTrue(result.Length == 0); 
        }

        private static string ReadFileContent(string fileName)
        {
            string result;
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "SimpleTasksVerifier.Tests." + fileName;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}
