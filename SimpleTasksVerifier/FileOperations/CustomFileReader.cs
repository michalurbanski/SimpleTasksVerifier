using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTasksVerifier.FileOperations
{
    public class CustomFileReader : IDisposable
    {
        private string _fileName;
        private Stream _stream; 

        public CustomFileReader(string fileName)
        {
            _fileName = fileName; 
        }

        public CustomFileReader(Stream stream)
        {
            _stream = stream; 
        }

        public IEnumerable<string> ReadFile()
        {
            string line;
            List<string> lines = new List<string>();

            using (StreamReader reader = CreateStreamReader())
            {
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }

        private StreamReader CreateStreamReader()
        {
            if(!string.IsNullOrEmpty(_fileName))
            {
                return new StreamReader(_fileName);
            }

            if(_stream != null)
            {
                return new StreamReader(_stream);
            }

            throw new ArgumentNullException("Wrong constructor used");
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _stream.Dispose(); 
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
