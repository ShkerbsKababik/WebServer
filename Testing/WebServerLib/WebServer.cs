using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebServerLib.Controllers;
using WebServerLib.Exceptions;
using WebServerLib.MiddleWares;
using WebServerLib.Pipelines;
using WebServerLib.QueryServers;

namespace WebServerLib
{
    public sealed partial class WebServer
    {
        // 1) want to make exception handler (it will log errors and it will be switchable)
        // 2) want to create Router
        // 3) want to create Builder in which logger router ip-configs will able to change

        readonly MiddlewaresPipeline _middlewaresPipeline;
        readonly ControllersPipeline _controllersPipeline;
        readonly HttpListener _listener;

        readonly IQueryHandler _controllerQueryHandler;
        readonly IQueryHandler _staticFileQueryHandler;
      
        public WebServer()
        {
            _middlewaresPipeline = new MiddlewaresPipeline();
            _controllersPipeline = new ControllersPipeline();
            _listener = new HttpListener();

            _controllerQueryHandler = new ControllerQueryHandler(
                _middlewaresPipeline,
                _controllersPipeline);

            _staticFileQueryHandler = new StaticFileQueryHandler(
                _middlewaresPipeline); 
        }
        public void Run()
        {
            Diagnose();
            _listener.Start();
            while (true)
                try {
                    ThreadPool.QueueUserWorkItem((object obj) => {
                        Serve(_listener.GetContext());
                    });
                }
                catch (Exception e){ }
        }
        void Serve(HttpListenerContext context)
        {
            if (context.Request.Url.IsFile)
                _staticFileQueryHandler.Serve(context);
            else
                _controllerQueryHandler.Serve(context); 
        }
    }
}
