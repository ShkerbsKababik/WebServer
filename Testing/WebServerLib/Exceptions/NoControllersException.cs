using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServerLib.Exceptions
{
    internal sealed class NoControllersException : Exception
    {
        public NoControllersException() : base("server does not have any controllers to serve") { }
    }
}
