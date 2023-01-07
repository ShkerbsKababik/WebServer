using System;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using WebServerLib.Controllers;
using WebServerLib.Exceptions;
using WebServerLib.MiddleWares;
using WebServerLib.Pipelines;

namespace WebServerLib
{
    public sealed partial class WebServer
    {
        // 1) identify for different kinds of static files
        // 2) info parser from http-query
        // 3) builder
        // 4) static files caching

        MiddlewaresPipeline _middlewaresPipeline;
        ControllersPipeline _controllersPipeline;
        HttpListener _listener;

        public WebServer()
        {
            _middlewaresPipeline = new MiddlewaresPipeline();
            _controllersPipeline = new ControllersPipeline();
            _listener = new HttpListener();
        }
        public void Run()
        {
            _listener.Start();
            while (true)
                try
                {
                    ThreadPool.QueueUserWorkItem((object obj) => {
                        Serve(_listener.GetContext());
                    });
                }
                catch(Exception e) { _logger.Log(e); }
        }

        Action<HttpListenerContext> ChooseQueryHandler(HttpListenerContext context)
        {
            if (context.Request.Url.IsFile)
                return StaticFileQueryHandler;
            return ControllerQueryHandler;
        }
        void Serve(HttpListenerContext context) 
            => ChooseQueryHandler(context)(context);

        public void AddController(IController controller)
        {
            foreach (IController item in _controllersPipeline.Controllers)
                if (controller.Name == item.Name)
                    throw new ControllerAlreadyExistsException();

            _controllersPipeline.Controllers.Add(controller);
        }
        public void AddMiddleware(IMiddleware middleware)
        {
            foreach (IController item in _middlewaresPipeline.Middlewares)
                if (middleware == item)
                    throw new MiddlewareAlreadyExcistsException();

            _middlewaresPipeline.Middlewares.Add(middleware);
        }s
    }
}
