using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServerLib;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new WebServer().Start();
            Console.ReadLine();
        }
    }
}
