using System;
namespace NWamp.Transport
{
    /// <summary>
    /// Interface representing WAMP client-server session.
    /// </summary>
    public interface IWampSession : IDisposable
    {
        /// <summary>
        /// Gets object representing connected web socket stream to client.
        /// </summary>
        IWampConnection Connection { get; }

        /// <summary>
        /// Gets string identifying current session.
        /// </summary>
        string SessionId { get; set; }

        /// <summary>
        /// Gets CURIE->URI mappings for current session.
        /// </summary>
        PrefixMap Prefixes { get; }
    }
}
