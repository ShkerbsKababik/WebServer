using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServerLib.Exceptions
{
    internal class ControllerAlreadyExistsException : Exception
    {
        public ControllerAlreadyExistsException() : base("controller with this name has already been added") { }
    }
}
