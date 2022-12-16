using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebServerLib.Controllers;
namespace WebServerLib
{
    public sealed class WebServer
    {
        List<IController> _controllers = new List<IController>();
        List<IComponent> _components = new List<IComponent>();
        HttpListener _listener = new HttpListener();

        public void Start()
        {
            try 
            {
                Console.WriteLine("1) add test configuration");
                AddTestConfiguration();

                Console.WriteLine("2) server has been started");
                _listener.Start();
                while (true)
                {
                    var context = _listener.GetContextAsync().Result;
                    ThreadPool.QueueUserWorkItem((aboba) => { SomeWorkWith(context); });
                }
            }
            catch(Exception ex) { Console.WriteLine(ex.ToString()); Console.Read(); }
        }
        public void SomeWorkWith(HttpListenerContext context)
        {
            Console.WriteLine(context.Request.Url.ToString());
            var responce = context.Response;
            byte[] buffer = Encoding.UTF8.GetBytes("hello world");
            responce.ContentLength64 = buffer.Length;
            responce.OutputStream.Write(buffer, 0, buffer.Length);
            Console.WriteLine("3.2)some work for user happned");
        }
        public async void SomeWorkWithAsync(HttpListenerContext context)
        {
            await Task.Run(() =>
            {
                Console.WriteLine(context.Request.Url.ToString());
                var responce = context.Response;
                byte[] buffer = Encoding.UTF8.GetBytes("hello world");
                responce.ContentLength64 = buffer.Length;
                responce.OutputStream.Write(buffer, 0, buffer.Length);
                Console.WriteLine("3.2)some work for user happned");
            });
        }
        public void AddTestConfiguration()
        {
            _listener.Prefixes.Add("http://127.0.0.1/bruh/");
            _listener.Prefixes.Add("http://127.0.0.1/bruh/home/");
        }
    }
}
