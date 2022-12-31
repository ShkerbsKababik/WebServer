using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServerLib.Exceptions
{
    internal sealed class NoMiddlewaresException : Exception
    {
        public NoMiddlewaresException() : base("server doesnt have any middlewares to serve") { }
    }
}
