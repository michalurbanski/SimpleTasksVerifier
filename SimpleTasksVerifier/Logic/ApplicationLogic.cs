﻿using SimpleTasksVerifier.Interfaces;
using SimpleTasksVerifier.Models;
using System.Collections.Generic;

namespace SimpleTasksVerifier.Logic
{
    public class ApplicationLogic
    {
        private readonly string _filePath;
        private readonly IFileReader _fileReader;
        private IEnumerable<string> _fileLines;
        private IFileProcessor _fileProcessor;

        public ApplicationLogic(string filePath, IFileReader fileReader, IFileProcessor fileProcessor)
        {
            _filePath = filePath;
            _fileReader = fileReader;
            _fileProcessor = fileProcessor; 
        }

        public void ReadFile()
        {
            _fileLines = _fileReader.ReadFile(); 
        }

        public void ProcessFile()
        {
            _fileProcessor.ProcessFile(); 
        }

        public IEnumerable<TaskResult> GetResults()
        {
            return new List<TaskResult> { new TaskResult() };
        }
    }
}
