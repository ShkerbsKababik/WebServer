using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace WebServerLib
{
    public sealed class WebServer
    {
        public void Run() => new HttpListener().Start();
    }
}
