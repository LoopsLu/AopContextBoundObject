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

        // No matter what the method will return a value or not, 
        // the method in attribute can be execute
        [MethodLog]
        public bool Create()
        {
            Console.WriteLine(string.Format("Create a file : {0}", _file));
            return true;
        }

        [MethodPreprocess]
        public void Delete()
        {
            Console.WriteLine(string.Format("Delete a file : {0}", _file));
        }
    }
}
