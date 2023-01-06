using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebServerLib.Controllers;
using WebServerLib.Pipelines;

namespace WebServerLib.QueryServers
{
    internal class ControllerQueryHandler : IQueryHandler
    {
        readonly MiddlewaresPipeline _middlewaresPipeline;
        readonly ControllersPipeline _controllersPipeline;
        public ControllerQueryHandler(
            MiddlewaresPipeline middlewaresPipeline, 
            ControllersPipeline controllersPipeline)
        {
            _middlewaresPipeline = middlewaresPipeline;
            _controllersPipeline = controllersPipeline;
        }
        public void Serve(HttpListenerContext context) 
        { 
        
        }
    }
}
