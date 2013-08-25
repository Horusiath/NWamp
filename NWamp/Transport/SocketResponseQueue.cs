using NWamp.Messages;
using System;

namespace NWamp.Transport
{
    /// <summary>
    /// Implementation of <see cref="IResponseQueue"/> using web socket as message transport medium.
    /// </summary>
    public class SocketResponseQueue : IResponseQueue
    {
        /// <summary>
        /// Queues a new <paramref name="message"/> to be sent to 
        /// WAMP client identified by <paramref name="sessionId"/>.
        /// </summary>
        /// <param name="sessionId">WAMP client sesssion identifier</param>
        /// <param name="message">WAMP message to send</param>
        public void Send(string sessionId, IMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
