using System.Linq;
using Alchemy;
using NWamp.Transport;
using System.Net;
using System.Collections.Generic;

namespace NWamp
{
    using Alchemy.Classes;
    using System;

    /// <summary>
    /// Concrete implementation of WAMP server host using Alchemy web sockets.
    /// </summary>
    public class AlchemyWampHost : BaseWampHost, IDisposable
    {
        /// <summary>
        /// Additional mapper used for mapping alchemy <see cref="UserContext"/> objects to <see cref="IWampSession"/>.
        /// </summary>
        private readonly IDictionary<EndPoint, IWampSession> _endpointSessions;

        /// <summary>
        /// Alchemy web socket server object.
        /// </summary>
        private readonly WebSocketServer _server;

        /// <summary>
        /// Gets an Alchemy web socket server object.
        /// </summary>
        public WebSocketServer Server { get { return _server; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlchemyWampHost"/> class.
        /// </summary>
        /// <param name="address">IP address for current host</param>
        /// <param name="port">Listening port</param>
        public AlchemyWampHost(IPAddress address, int port)
            : base(new NewtonsoftWampMessageProvider())
        {
            _endpointSessions = new Dictionary<EndPoint, IWampSession>();
            _server = new WebSocketServer(port, address)
                          {
                              OnReceive = OnReceive,
                              OnConnected = OnConnected,
                              OnDisconnect = OnDisconnect,
                              OnSend = OnSend
                          };
        }

        /// <summary>
        /// Starts listening, waiting for incoming connections.
        /// </summary>
        public void Start()
        {
            _server.Start();
        }

        /// <summary>
        /// Stops listening.
        /// </summary>
        public void Stop()
        {
            Dispose();
            _server.Stop();
        }

        /// <summary>
        /// Disposes current host, closing all sessions.
        /// </summary>
        public void Dispose()
        {
            var sessions = Sessions.ToArray();
            foreach (var session in sessions)
            {
                session.Dispose();
                Sessions.RemoveSession(session.SessionId);
            }

            _server.Dispose();
        }

        /// <summary>
        /// Method called when new web socket client has connected.
        /// </summary>
        /// <param name="context">Alchemy context for incoming clients</param>
        private void OnConnected(UserContext context)
        {
            var connection = new AlchemyWampConnection(context);
            OnConnected(connection);
        }

        /// <summary>
        /// Method called when new message from client has been received.
        /// </summary>
        /// <param name="context">Alchemy web socket client context</param>
        protected virtual void OnReceive(UserContext context)
        {
            var session = GetSession(context);
            ReceiveJson(session, context.DataFrame.ToString());
        }

        /// <summary>
        /// Method called when new message has been send to client.
        /// </summary>
        /// <param name="context">Alchemy web socket client context</param>
        private void OnSend(UserContext context)
        {
            //TODO: ???
        }

        /// <summary>
        /// Method called when existing web socket client has disconnected.
        /// </summary>
        /// <param name="context">Alchemy web socket client context</param>
        private void OnDisconnect(UserContext context)
        {
            var session = GetSession(context);
            _endpointSessions.Remove(context.ClientAddress);

            OnDisconnected(session);
        }

        /// <summary>
        /// Returns WAMP session object for provided <see cref="UserContext"/> instance.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private IWampSession GetSession(UserContext context)
        {
            IWampSession session;
            return _endpointSessions.TryGetValue(context.ClientAddress, out session) ? session : null;
        }

        /// <summary>
        /// Initalizes a new WAMP session.
        /// </summary>
        /// <param name="connection"><see cref="AlchemyWampConnection"/> instance</param>
        /// <returns></returns>
        protected override IWampSession InitializeWampSession(IWampConnection connection)
        {
            var alchemyConnection = connection as AlchemyWampConnection;
            if (alchemyConnection == null)
            {
                throw new ArgumentException("Provided WAMP connection was not of type AlchemyWampConnection");    
            }

            var session = base.InitializeWampSession(connection);
            _endpointSessions.Add(alchemyConnection.Context.ClientAddress, session);

            return session;
        }
    }
}
