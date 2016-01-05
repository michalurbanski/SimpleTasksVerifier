using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTasksVerifier.FileOperations;
using SimpleTasksVerifier.Logic;
using SimpleTasksVerifier.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTasksVerifier.Tests.ApplicationTests
{
    [TestClass]
    public class ApplicationMainTests
    {
        [TestMethod]
        public void Test_ValidFile_ShouldReturnAnyResults()
        {
            string filePath = @"c:\samplefile.txt";
            CustomFileStreamReader reader = new CustomFileStreamReader(filePath);
            SafeFileReader safeReader = new SafeFileReader(reader); 
            ApplicationLogic application = new ApplicationLogic(filePath, safeReader, new FileProcessor());

            application.ReadFile();
            application.ProcessFile();
            IEnumerable<TaskResult> results = application.GetResults();

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_ReadingEmptyFilePath_ShouldThrowException()
        {
            string filePath = string.Empty;

            CustomFileStreamReader reader = new CustomFileStreamReader(filePath);
            SafeFileReader safeReader = new SafeFileReader(reader);
            ApplicationLogic application = new ApplicationLogic(filePath, safeReader, new FileProcessor());

            application.ReadFile();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_NotExistingFile_ShouldThrowException()
        {
            string filePath = @"c:\notexistingdummyfile.zz";
            CustomFileStreamReader reader = new CustomFileStreamReader(filePath);
            SafeFileReader safeReader = new SafeFileReader(reader);
            ApplicationLogic application = new ApplicationLogic(filePath, safeReader, new FileProcessor());

            application.ReadFile();
        }
    }
}
