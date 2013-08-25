using NWamp.Messages;
using System;
using System.Collections.Concurrent;

namespace NWamp.Transport
{
    /// <summary>
    /// Implementation of <see cref="IResponseQueue"/> using web socket as message transport medium.
    /// </summary>
    public class SocketResponseQueue : IResponseQueue
    {
        /// <summary>
        /// Internal queue used for storing and retrieving connections.
        /// </summary>
        private readonly BlockingCollection<Tuple<string, IMessage>> _queue;

        /// <summary>
        /// Initializes a new instance of the <see cref="SocketResponseQueue"/> class.
        /// </summary>
        public SocketResponseQueue()
        {
            _queue = new BlockingCollection<Tuple<string, IMessage>>();
        }

        /// <summary>
        /// Queues a new <paramref name="message"/> to be sent to 
        /// WAMP client identified by <paramref name="sessionId"/>.
        /// </summary>
        /// <param name="sessionId">WAMP client sesssion identifier</param>
        /// <param name="message">WAMP message to send</param>
        public void Send(string sessionId, IMessage message)
        {
            _queue.TryAdd(Tuple.Create(sessionId, message));
        }

        public Tuple<string, IMessage> Receive()
        {
            return _queue.Take();
        } 
    }
}
