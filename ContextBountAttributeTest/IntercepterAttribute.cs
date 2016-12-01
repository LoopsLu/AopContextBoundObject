using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ContextBountAttributeTest
{
    //貼在類上的標簽
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false)]
    public sealed class InterceptorAttribute : ContextAttribute, IContributeObjectSink
    {
        public InterceptorAttribute()
            : base("Interceptor")
        { }

        //實現IContributeObjectSink接口當中的消息接收器接口
        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink nextSink)
        {
            return new InterceptorHandler(nextSink);
        }
    }
}
