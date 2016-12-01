using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextBountAttributeTest
{
    public interface IFileAccess
    {
        bool Create();
        void Delete();
    }

}
