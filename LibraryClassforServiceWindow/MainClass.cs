using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClassforServiceWindow
{
   
    public class LogFile : System.IDisposable
    {
        StreamWriter file;

        public string FileName { get; private set; }

        public LogFile()
        {
            CreateFile();
        }

        ~LogFile()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (file != null)
            {
                file.Close();
            }
        }

        private void CreateFile()
        {
            FileName = Path.GetTempFileName();
            file = File.CreateText(FileName);
        }

        public void Write(string text)
        {
            file.WriteLine(text);
        }
    }
}
