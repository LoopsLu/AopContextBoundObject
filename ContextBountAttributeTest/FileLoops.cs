using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextBountAttributeTest
{
    [Interceptor]
    class FileLoops : ContextBoundObject, IFileAccess
    {
        private string _file; 

        public FileLoops(string filename)
        { _file = filename; }

        [MethodLog]
        public bool Create()
        {
            Console.WriteLine(string.Format("Create a file : {0}", _file));
            return true;
        }
    }
}
