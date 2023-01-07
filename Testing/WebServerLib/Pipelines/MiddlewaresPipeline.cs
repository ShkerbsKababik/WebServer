using System.Collections.Generic;
using System.Net;
using WebServerLib.MiddleWares;

namespace WebServerLib
{
    internal class MiddlewaresPipeline
    {
        public List<IMiddleware> Middlewares = new List<IMiddleware>();
        public void Run(HttpListenerContext context)
        {
            foreach (IMiddleware middleware in Middlewares)
                middleware.Run(context.Request);
        }
    }
}
