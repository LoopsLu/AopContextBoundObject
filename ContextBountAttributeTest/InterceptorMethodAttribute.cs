using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ContextBountAttributeTest
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public abstract class InterceptorMethodAttribute : Attribute
    {
        public abstract void OnExecuting();
        public abstract void OnExecuted();
    }
    public sealed class MethodLogAttribute : InterceptorMethodAttribute
    {
        public override void OnExecuted() { Console.WriteLine("Logged"); }
        public override void OnExecuting() { }
    }
    public sealed class MethodPreprocessAttribute : InterceptorMethodAttribute
    {
        public override void OnExecuted() { }
        public override void OnExecuting() { Console.WriteLine("Logging"); }
    }

}
