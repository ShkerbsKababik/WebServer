using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServerLib.Exceptions;

namespace WebServerLib
{
    public sealed partial class WebServer
    {
        private void Diagnose()
        {
            ThrowIfListenerEmpty();
            ThrowIfNoContollers();
            ThrowIfMiddlewaresNoBuilded();
        }
        private void ThrowIfNoContollers()
        {
            if (_controllers == null || _controllers.Count == 1) 
                throw new NoControllersException();
        }
        private void ThrowIfNoMiddlewares()
        {
            if (_middlewares == null || _middlewares.Count == 0)
                throw new NoMiddlewaresException();
        }
        private void ThrowIfListenerEmpty()
        { 
            if(_listener == null)
                throw new NoLIstenerException();
        }
        private void ThrowIfMiddlewaresNoBuilded()
        { 
            if(!_middlewaresPipeline.Builded)
                throw new MiddlewaresNoBuidldedException()
        }
    }
}