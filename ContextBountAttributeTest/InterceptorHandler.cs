using System;
using System.Runtime.Remoting.Messaging;

namespace ContextBountAttributeTest
{
    internal class InterceptorHandler : IMessageSink
    {
        private IMessageSink nextSink;
        public IMessageSink NextSink
        {
            get
            {
                return nextSink;
            }
        }

        public InterceptorHandler(IMessageSink next)
        {
            this.nextSink = next;
        }

        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            return null;
        }

        //同步處理方法 
        public IMessage SyncProcessMessage(IMessage msg)
        {
            IMessage retMsg = null;

            //方法調用消息接口
            IMethodCallMessage call = msg as IMethodCallMessage;

            //如果被調用的方法沒打MyInterceptorMethodAttribute標簽
            if (call == null || (Attribute.GetCustomAttribute(call.MethodBase, typeof(InterceptorMethodAttribute))) == null)
            {
                retMsg = nextSink.SyncProcessMessage(msg);
            }
            //如果打了MyInterceptorMethodAttribute標簽
            else
            {
                if (Attribute.GetCustomAttribute(call.MethodBase, typeof(MethodLogAttribute)) != null )
                {
                    MethodLogAttribute log = new MethodLogAttribute();
                    log.OnExecuted();
                }
                    
                retMsg = nextSink.SyncProcessMessage(msg);

                if (Attribute.GetCustomAttribute(call.MethodBase, typeof(MethodPreprocessAttribute)) != null)
                {
                    MethodPreprocessAttribute preprocess = new MethodPreprocessAttribute();
                    preprocess.OnExecuting();
                }
            }

            return retMsg;
        }
    }
}