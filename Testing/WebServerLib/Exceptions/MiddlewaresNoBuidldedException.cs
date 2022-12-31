using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServerLib.Exceptions
{
    internal sealed class MiddlewaresNoBuidldedException : Exception
    {
        public MiddlewaresNoBuidldedException() : base("middlewares has not been builded") { }
    }
}
