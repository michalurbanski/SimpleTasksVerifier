using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTasksVerifier.FileOperations;
using SimpleTasksVerifier.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTasksVerifier.Tests.IntegrationTests
{
    [TestClass]
    public class FileReaderTests
    {
        [TestMethod]
        public void Test_ShouldBeAble_ToReadExistingFile()
        {
            // Arrange
            string fileName = "SampleDataFile.txt"; // File created in project post-build event
            string folder = FileHelper.GetApplicationDataFolder();

            CustomFileStreamReader reader = new CustomFileStreamReader(folder, fileName);
            SafeFileReader safeReader = new SafeFileReader(reader);

            // Act 
            var result = safeReader.ReadFile();

            // Assert
            Assert.IsNotNull(result); 
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Test_StandardReader_ShouldThrowException_WhenReadingNotExistingFile()
        {
            // Arrange
            string filePath = "c:\\NotExistingFile";

            CustomFileStreamReader reader = new CustomFileStreamReader(filePath);

            // Act 
            var result = reader.ReadFile();

            // Assert
        }

        [TestMethod]
        public void Test_SafeReader_ShouldReturnEmptyCollection_WhenReadingNotExistingFile()
        {
            // Arrange
            string filePath = "c:\\NotExistingFile";

            CustomFileStreamReader reader = new CustomFileStreamReader(filePath);
            SafeFileReader safeReader = new SafeFileReader(reader);

            // Act 
            var result = safeReader.ReadFile();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }
    }
}
