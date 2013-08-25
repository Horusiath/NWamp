namespace NWamp.Transport
{
    /// <summary>
    /// Defalt implementation of <see cref="IWampSession"/> interface.
    /// </summary>
    public class WampSession : IWampSession
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WampSession"/> class.
        /// </summary>
        /// <param name="connection"></param>
        public WampSession(IWampConnection connection)
        {
            Connection = connection;
            Prefixes = new PrefixMap();
            SessionId = IdGenerator.GenerateSessionId();
        }

        /// <summary>
        /// Gets CURIE->URI mappings for current session.
        /// </summary>
        public PrefixMap Prefixes { get; private set; }

        /// <summary>
        /// Gets object representing connected web socket stream to client.
        /// </summary>
        public IWampConnection Connection { get; private set; }

        /// <summary>
        /// Gets string identifying current session.
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// Disposes current session, closing a WAMP connection.
        /// </summary>
        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.Dispose();
                Connection = null;
            }

        }
    }
}
