using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebServerLib.Controllers
{
    public interface IController
    {
        string Name { get; set; }
        void Run(HttpListenerContext context);
    }
}
