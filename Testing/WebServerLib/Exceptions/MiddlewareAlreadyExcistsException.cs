using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServerLib.Exceptions
{
    internal class MiddlewareAlreadyExcistsException : Exception
    {
        public MiddlewareAlreadyExcistsException() : base("this middleware has already been added") { }
    }
}
