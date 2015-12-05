using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using SimpleTasksVerifier.Helpers; 

namespace SimpleTasksVerifier.Tests
{
    [TestClass]
    public class FileExistenceTests
    {
        #region Tests

        [TestMethod]
        public void Test_Get_Current_FileName_ShouldSucceed()
        {
            // Arrange
            string expected = "FileExistenceTests.cs";

            // Act 
            string fileName = GetCurrentFileName();

            // Assert
            Assert.AreEqual(expected, fileName);
        }


        [TestMethod]
        public void Test_Check_If_File_Exists_ExistingFile()
        {
            // Arrange
            string fileName = GetCurrentFileName();
            string path = GetCurrentFilePath();

            // Act 
            bool isFileExists = FileHelper.CheckIfFileExists(path, fileName);

            // Assert
            Assert.IsTrue(isFileExists);
        }

        [TestMethod]
        public void Test_Check_If_File_Exists_NullFileName()
        {
            // Arrange
            string fileName = null;
            string path = ""; // Path does not matter in case of null or empty fileName

            // Act 
            bool isFileExsits = FileHelper.CheckIfFileExists(path, fileName);

            // Assert
            Assert.IsFalse(isFileExsits);
        }

        [TestMethod]
        public void Test_Check_If_File_Exists_NullPath()
        {
            // Arrange
            string fileName = "test";
            string path = null;

            // Act 
            bool isFileExists = FileHelper.CheckIfFileExists(path, fileName);

            // Assert
            Assert.IsFalse(isFileExists);
        }

        [TestMethod]
        public void Test_Check_If_File_Exists_WrongPath()
        {
            // Arrange
            string fileName = "notexistingFile.cs";
            string path = Path.GetRandomFileName();

            // Act 
            bool isFileExists = FileHelper.CheckIfFileExists(path, fileName);

            // Assert
            Assert.IsFalse(isFileExists);
        } 

        [TestMethod]
        public void Test_GetUserApplicationDataFolder_ShouldSucceed()
        {
            // Arrange

            // Act 
            string result = FileHelper.GetSampleDataFilePath();

            // Assert
            Assert.IsTrue(result.EndsWith($"{Consts.Application.ApplicationName}\\SampleDataFile.txt")); 
        }

        #endregion

        #region Helper methods

        private static string GetCurrentFileName()
        {
            string fullFilePath = GetCurrentFileFullPath();
            string fileName = Path.GetFileName(fullFilePath);

            return fileName;
        }

        private static string GetCurrentFilePath()
        {
            string fullFilePath = GetCurrentFileFullPath();
            string path = Path.GetDirectoryName(fullFilePath);

            return path;
        }

        private static string GetCurrentFileFullPath()
        {
            return new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        } 

        #endregion
    }
}
