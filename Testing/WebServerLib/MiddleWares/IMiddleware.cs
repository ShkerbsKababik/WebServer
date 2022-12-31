using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebServerLib.MiddleWares
{
    public interface IMiddleware
    {
        void Run(HttpListenerRequest request);
    }
}
