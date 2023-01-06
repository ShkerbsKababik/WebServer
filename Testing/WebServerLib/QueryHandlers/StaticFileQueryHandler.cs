using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebServerLib.Pipelines;

namespace WebServerLib.QueryServers
{
    internal class StaticFileQueryHandler : IQueryHandler
    {
        readonly MiddlewaresPipeline _middlewaresPipeline;
        public StaticFileQueryHandler(MiddlewaresPipeline middlewaresPiepline) 
            => _middlewaresPipeline = middlewaresPiepline;
        public void Serve(HttpListenerContext context) 
        {
                
        }
    }
}
