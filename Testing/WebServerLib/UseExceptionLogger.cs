using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServerLib.ExceptionLoggers;

namespace WebServerLib
{
    public sealed partial class WebServer
    {
        IExceptionLogger _logger;
        bool _loggerEnabled = false;
        public void UseExceptionLogger()
        { 
            _loggerEnabled = true;
            _logger = new BaseExceptionLogger();
        }
        public void UseExceptionLogger(IExceptionLogger logger)
        {
            _loggerEnabled = true;
            _logger = logger;
        }
    }
}
