using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTasksVerifier.FileOperations;
using SimpleTasksVerifier.Logic;
using SimpleTasksVerifier.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moq;
using SimpleTasksVerifier.Interfaces;

namespace SimpleTasksVerifier.Tests.ApplicationTests
{
    [TestClass]
    public class ApplicationMainTests
    {
        [TestMethod]
        public void Test_ValidFile_ShouldReturnAnyResults()
        {
            string filePath = @"c:\samplefile.txt";
            
            var mock = new Mock<IFileReader>();
            mock.Setup(s => s.ReadFile()).Returns(new List<string>());

            ApplicationLogic application = new ApplicationLogic(filePath, mock.Object, new FileProcessor());

            application.ReadFile();
            application.ProcessFile();
            IEnumerable<TaskResult> results = application.GetResults();

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_ReadingEmptyFilePath_ShouldThrowException()
        {
            string filePath = string.Empty;

            var reader = new CustomFileStreamReader(filePath);
            ApplicationLogic application = new ApplicationLogic(filePath, reader, new FileProcessor());

            application.ReadFile();
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Test_NotExistingFile_ShouldThrowException()
        {
            string filePath = @"c:\notexistingdummyfile.zz";
            var reader = new CustomFileStreamReader(filePath);
            ApplicationLogic application = new ApplicationLogic(filePath, reader, new FileProcessor());

            application.ReadFile();
        }
    }
}
