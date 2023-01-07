using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebServerLib.Exceptions;

namespace WebServerLib
{
    public sealed partial class WebServer
    {
        void StaticFileQueryHandler(HttpListenerContext context)
        {
            if (_staticFilesEnabled) throw new StaticFilesDisabledException();
        }
        void ControllerQueryHandler(HttpListenerContext context)
        {
            _middlewaresPipeline.Run(context);
            _controllersPipeline.Run(context, "def");
        }
    }
}
