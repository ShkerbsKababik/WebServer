using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServerLib.ExceptionLoggers
{
    internal sealed class BaseExceptionLogger : IExceptionLogger
    {
        public void Log(Exception e) =>
            Console.WriteLine(e.ToString());
    }
}
