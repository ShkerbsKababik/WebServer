using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServerLib.Exceptions
{
    internal sealed class NoLIstenerException : Exception
    {
        internal NoLIstenerException() : base("server doesnt have listener (wtf??)") { }
    }
}
