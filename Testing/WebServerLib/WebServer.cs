using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebServerLib.Controllers;
using WebServerLib.Exceptions;
using WebServerLib.MiddleWares;
using WebServerLib.Pipelines;

namespace WebServerLib
{
    public sealed partial class WebServer
    {
        // 1) want to make exception handler (it will log errors and it will be switchable)
        // 2) want to create Router

        private MiddlewaresPipeline _middlewaresPipeline;
        private ControllersPipeline _controllersPipeline;
        private HttpListener _listener;

        public WebServer()
        {
            _middlewaresPipeline = new MiddlewaresPipeline();
            _controllersPipeline = new ControllersPipeline();
            _listener = new HttpListener();
        }
        public void Run()
        {
            Diagnose();
            _listener.Start();
            while(true)
            {
                try
                {
                    ThreadPool.QueueUserWorkItem((object obj) => { 
                        Serve(_listener.GetContext()); 
                    });
                }
                catch (Exception e) { 
                    // 1)s
                }
            }
        }
        private void Serve(HttpListenerContext context)
        {
            // 2) there will be call for Router
            _middlewaresPipeline.Run(context.Request);
            _controllersPipeline.Run(context, "def");
        }
    }
}
