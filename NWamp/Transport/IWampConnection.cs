using System;
namespace NWamp.Transport
{
    /// <summary>
    /// Interface used for abstracting web socket connection implementations for WAMP clients connected to server.
    /// </summary>
    public interface IWampConnection : IDisposable
    {
        /// <summary>
        /// Sends a JSON string through web socket stream.
        /// </summary>
        /// <param name="json"></param>
        void Send(string json);
    }
}
