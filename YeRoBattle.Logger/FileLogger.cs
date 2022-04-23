using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeRoBattle.Logger
{
    public class FileLogger : ILogger
    {
        private string path = Directory.GetCurrentDirectory();
        public void WriteLine(string text)
        {
            File.AppendAllText(Path.Combine(path, "test.txt"), text + Environment.NewLine);
        }
    }
}
