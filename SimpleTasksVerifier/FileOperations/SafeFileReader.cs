using SimpleTasksVerifier.Helpers;
using SimpleTasksVerifier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTasksVerifier.FileOperations
{
    public class SafeFileReader : IFileReader
    {
        private IFileReader _reader; 

        public SafeFileReader(IFileReader fileReader)
        {
            _reader = fileReader; 
        }

        public string FilePath
        {
            get
            {
                return _reader.FilePath; 
            }
        }

        public IEnumerable<string> ReadFile()
        {
            try
            {
                // Check if file exists
                if (FileHelper.CheckIfFileExists(_reader.FilePath))
                {
                    return _reader.ReadFile();
                }

                return new List<string>();
            }
            catch (Exception ex)
            {
                //TODO: log exception
                return new List<string>(); 
            }
        }
    }
}
