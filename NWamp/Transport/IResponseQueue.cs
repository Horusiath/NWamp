using NWamp.Messages;

namespace NWamp.Transport
{
    /// <summary>
    /// Interface used for queueing requests of sending WAMP messages back to clients.
    /// </summary>
    public interface IResponseQueue
    {
        /// <summary>
        /// Queues a new <paramref name="message"/> to be sent to 
        /// WAMP client identified by <paramref name="sessionId"/>.
        /// </summary>
        /// <param name="sessionId">WAMP client sesssion identifier</param>
        /// <param name="message">WAMP message to send</param>
        void Send(string sessionId, IMessage message);
    }
}
