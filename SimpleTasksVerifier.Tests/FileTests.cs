using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace SimpleTasksVerifier.Tests
{
    [TestClass]
    public class FileTests
    {
        [TestMethod]
        public void Test_Get_Current_FileName_ShouldSucceed()
        {
            // Arrange
            string expected = "FileTests.cs";

            // Act 
            string fullFilePath = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            string fileName = Path.GetFileName(fullFilePath); 

            // Assert
            Assert.AreEqual(expected, fileName); 
        }

        [TestMethod]
        public void Test_Check_If_File_Exists_ExistingFile()
        {
            // Arrange
            string path = ""; 

            // Act 

            // Assert

            Assert.Inconclusive(); 
        }

        [TestMethod]
        public void Test_Check_If_File_Exists_NotExistingFile()
        {
            // Arrange

            // Act 

            // Assert

            Assert.Inconclusive(); 
        }
    }
}
