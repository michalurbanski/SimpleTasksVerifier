using SimpleTasksVerifier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTasksVerifier.Logic
{
    public class ApplicationLogic
    {
        private string _filePath;

        public ApplicationLogic(string filePath)
        {
            _filePath = filePath;
        }

        public void ReadFile()
        {
        }

        public void ProcessFile()
        {
            
        }

        public IEnumerable<TaskResult> GetResults()
        {
            return new List<TaskResult> { new TaskResult() };
        }
    }
}
