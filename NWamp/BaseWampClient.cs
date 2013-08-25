using System.Collections.Generic;
using System.Threading.Tasks;
using NWamp.Messages;
using System;
using NWamp.Transport;

namespace NWamp
{
    /// <summary>
    /// Abstract class representing WAMP client object.
    /// </summary>
    public abstract class BaseWampClient : IDisposable
    {
        public IWampSession Session { get; protected set; }

        public IDictionary<string, Task> PendingCalls { get; protected set; }

        protected virtual void OnConnectionInitialized(WelcomeMessage message)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(string topicUri)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(string topicUri)
        {
            throw new NotImplementedException();
        }

        public void Publish(string topicUri, object eventObject, bool excludeMe = false)
        {
            throw new NotImplementedException();
        }

        public void PublishExcept(string topicUri, object eventObject, params string[] exculdedSessions)
        {
            throw new NotImplementedException();
        }

        public void PublishTo(string topicUri, object eventObject, params string[] eligibleSessions)
        {
            throw new NotImplementedException();
        }

        public object Call(string procUri, params object[] args)
        {
            throw new NotImplementedException();
        }

        public Task CallAsyn(string procUri, params object[] args)
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }

        protected virtual MessageContext CreateMessageContext(IMessage message)
        {
            var messageContext = new MessageContext
                                     {
                                         Message = message,
                                         SenderSession = Session
                                     };
            return messageContext;
        }
    }
}
