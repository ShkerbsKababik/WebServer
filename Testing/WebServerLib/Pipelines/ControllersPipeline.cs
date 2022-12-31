using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebServerLib.Controllers;
using WebServerLib.MiddleWares;

namespace WebServerLib.Pipelines
{
    internal class ControllersPipeline
    {
        internal List<IController> Controllers;
        internal ControllersPipeline()
        {
            Controllers = new List<IController>();
        }
        internal void Run(HttpListenerContext context, string name)
        {
            foreach (IController controller in Controllers)
                if (name == controller.Name)
                {
                    controller.Run(context);
                    break;
                }
        }
    }
}
