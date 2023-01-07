using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebServerLib;
using WebServerLib.Controllers;
using WebServerLib.MiddleWares;

namespace Testing
{
    internal class Programр
    {
        static void Main(string[] args)
        {
            var server = new WebServer();
            
            server.Run();
        }
    }
    public class MyController : IController
    {
        string IController.Name { get => "mycontroller";}

        public void Run(HttpListenerContext context)
        {
            byte[] buffer = Encoding.UTF8.GetBytes("hello world !");
            var responce = context.Response;
            responce.ContentLength64 = buffer.Length;
            responce.OutputStream.Write(buffer, 0, buffer.Length);
            responce.Close();
        }
    }
    public class MyMiddleware : IMiddleware
    {
        public void Run(HttpListenerRequest request)
        {
            // some work
        }
    }
}
