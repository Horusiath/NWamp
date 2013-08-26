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
    public abstract class BaseWampClient : IWampClient
    {
        protected BaseWampClient()
        {
            
        }

        public bool IsConnected { get; private set; }

        public IEnumerable<KeyValuePair<string, string>> Prefixes { get; private set; }

        public void Connect(string address)
        {
            throw new NotImplementedException();
        }

        public void Prefix(string curie, string uri)
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

        public void Publish(string topicUri, object eventObject, bool excludeSelf = false)
        {
            throw new NotImplementedException();
        }

        public void PublishTo(string topicUri, object eventObject, IEnumerable<string> eligibleSessions)
        {
            throw new NotImplementedException();
        }

        public void PublishExcept(string topicUri, object eventObject, IEnumerable<string> excludeSessions)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> CallAsync<TResult>(string procUri, params object[] arguments)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
