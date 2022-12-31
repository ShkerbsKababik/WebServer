using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServerLib.Exceptions
{
    internal sealed class ServerFatalException : Exception
    {
        public ServerFatalException() : base("server fatal exception occured (something went wrong)") { }
    }
}
