using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServerLib.Exceptions
{
    internal sealed class UserServeFailedException : Exception
    {
        public UserServeFailedException() : base("failed to serve user / something went wrong") { }
    }
}
