using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebServerLib.MiddleWares;
using WebServerLib.Pipelines;

namespace WebServerLib
{
    internal class MiddlewaresPipeline
    {
        internal List<IMiddleware> _middlewares;
        private MiddlewaresPipelineDelegate _pipeline;
        internal bool Builded { get { return _pipeline != null; } }

        internal void Build(List<IMiddleware> middlewares)
        {
            foreach (IMiddleware middleware in middlewares)
                _pipeline += middleware.Run;
        }
        internal void Run(HttpListenerRequest request)
        {
            _pipeline(request);
        }
    }
}
