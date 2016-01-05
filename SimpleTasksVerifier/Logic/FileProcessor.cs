using System;
using SimpleTasksVerifier.Interfaces;
using SimpleTasksVerifier.Models;
using System.Collections.Generic;

namespace SimpleTasksVerifier.Logic
{
    public class FileProcessor : IFileProcessor
    {
        public IEnumerable<TaskResult> ProcessFile()
        {
            return new List<TaskResult> { new TaskResult()}; 
        }
    }
}
