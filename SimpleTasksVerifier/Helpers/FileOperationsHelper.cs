using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTasksVerifier.Helpers
{
    /// <summary>
    /// Operations on files
    /// </summary>
    public class FileOperationsHelper
    {
        public static IEnumerable<string> ReadFileLineByLine(string fileName)
        {
            string line;
            List<string> lines = new List<string>(); 

            using (StreamReader reader = new StreamReader(fileName))
            {
                while((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);  
                }
            }

            return lines; 
        }

        public static IEnumerable<string> ReadFileLineByLine(Stream stream)
        {
            string line;
            List<string> lines = new List<string>();

            using (StreamReader reader = new StreamReader(stream))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }
    }
}
