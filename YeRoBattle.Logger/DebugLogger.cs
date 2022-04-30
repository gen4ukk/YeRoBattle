using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeRoBattle.Logger
{
    public class DebugLogger : ILogger
    {
        public void WriteLine(string text)
        {
            Debug.WriteLine(text);
        }
    }
}
