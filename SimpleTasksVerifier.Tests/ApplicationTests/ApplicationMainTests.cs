using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTasksVerifier.Logic;
using SimpleTasksVerifier.Models;
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
            string filePath = string.Empty; 
            ApplicationLogic application = new ApplicationLogic(filePath);

            application.ReadFile();
            application.ProcessFile();
            IEnumerable<TaskResult> results = application.GetResults();

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }
    }
}
