using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServerLib
{
    public sealed partial class WebServer
    {
        string _staticFilesDirectory = "StaticFiles/";
        bool _staticFilesEnabled = false;

        public void UseStaticFiles() =>
            _staticFilesEnabled = true;
        public void UseStaticFiles(string filesDirectory)
        {
            _staticFilesDirectory = filesDirectory;
            _staticFilesEnabled = false;
        }
    }
}
