using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextBountAttributeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLoops fl = new FileLoops("abc");
            fl.Create();
            fl.Delete();

            Console.ReadLine();
        }
    }
}
