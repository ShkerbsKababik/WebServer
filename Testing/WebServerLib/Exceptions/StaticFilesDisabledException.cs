using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServerLib.Exceptions
{
    internal class StaticFilesDisabledException : Exception
    {
        public StaticFilesDisabledException() : base("static files disable and could not be called ") { }
    }
}
