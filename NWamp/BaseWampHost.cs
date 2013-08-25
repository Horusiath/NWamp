using System;
using System.Linq;
using System.Threading.Tasks;
using NWamp.Messages;
using NWamp.Messages.Handlers;
using NWamp.Rpc;
using NWamp.Topics;
using NWamp.Transport;
using System.Collections.Generic;
using System.Threading;

namespace NWamp
{
    /// <summary>
    /// Abstract class representing WAMP server host.
    /// </summary>
    public abstract class BaseWampHost : IDisposable
    {
        /// <summary>
        /// Sender task used for checking if ResponseQueue has some message to send and sending them.
        /// </summary>
        private Task _senderTask;

        /// <summary>
        /// Message provider used for message serialization and deserialization.
        /// </summary>
        protected IMessageProvider MessageProvider;

        /// <summary>
        /// Procedure scheduler used for message scheduling and management.
        /// </summary>
        protected IProcedureScheduler Scheduler;

        /// <summary>
        /// Response queue used for queueing responses to be sent to connected WAMP clients.
        /// </summary>
        protected SocketResponseQueue ResponseQueue;

        /// <summary>
        /// Collection fo registered methods to be called using WAMP RPC mechanism.
        /// </summary>
        protected IDictionary<Uri, ProcedureDefinition> Procedures;

        /// <summary>
        /// Collection of message handlers used for responing on incoming WAMP messages.
        /// </summary>
        protected IDictionary<MessageTypes, IMessageHandler> Handlers =
            new Dictionary<MessageTypes, IMessageHandler>
                {
                    {MessageTypes.Call,         new CallMessageHandler()},
                    {MessageTypes.Publish,      new PublishMessageHandler()},
                    {MessageTypes.Prefix,       new PrefixMessageHandler()},
                    {MessageTypes.Subscribe,    new SubscribeMessageHandler()},
                    {MessageTypes.Unsubscribe,  new UnsubscribeMessageHandler()}
                };

        /// <summary>
        /// Initializes a new instance of <see cref="BaseWampHost"/>.
        /// </summary>
        /// <param name="messageProvider">Message provider used for WAMP message JSON serialization/deserialization</param>
        /// <param name="typeResolver">Resolver used for converting deserialized JSON object into specific type instances</param>
        protected BaseWampHost(Uri listeningUri, IMessageProvider messageProvider, ITypeResolver typeResolver)
        {
            AddressUri = listeningUri;
            MessageProvider = messageProvider;
            Topics = new TopicCollection();
            ResponseQueue = new SocketResponseQueue();
            Scheduler = new ProcedureScheduler(ResponseQueue, typeResolver);
            Sessions = new DictionarySessionContainer();
            Procedures = new Dictionary<Uri, ProcedureDefinition>();
        }

        /// <summary>
        /// Gets listening URI address for current host.
        /// </summary>
        public Uri AddressUri { get; protected set; }

        /// <summary>
        /// Gets collection of currently active WAMP Pub/Sub topics.
        /// </summary>
        public TopicCollection Topics { get; protected set; }

        /// <summary>
        /// Gets list of active WAMP sessions connected to current host.
        /// </summary>
        public ISessionContainer Sessions { get; protected set; }


        /// <summary>
        /// Starts listening, waiting for incoming connections.
        /// </summary>
        public virtual void Start()
        {
            _senderTask = Task.Factory.StartNew(SendMessages);
        }

        /// <summary>
        /// Stops listening.
        /// </summary>
        public virtual void Stop()
        {
            if (_senderTask != null)
            {
                _senderTask.Dispose();
                _senderTask = null;
            }
        }

        /// <summary>
        /// Disposes current host, closing all sessions.
        /// </summary>
        public virtual void Dispose()
        {
            var sessions = Sessions.ToArray();
            foreach (var session in sessions)
            {
                session.Dispose();
                Sessions.RemoveSession(session.SessionId);
            }
        }

        /// <summary>
        /// Registers na new procedure to be callable using RPC mechanism.
        /// </summary>
        /// <param name="procedureDefinition">Definition of remote procedure</param>
        protected internal virtual BaseWampHost RegisterProcedure(ProcedureDefinition procedureDefinition)
        {
            procedureDefinition.ProcedureUri = GetProcedureUri(procedureDefinition.ProcedureUri);

            if (Procedures.ContainsKey(procedureDefinition.ProcedureUri))
                Procedures[procedureDefinition.ProcedureUri] = procedureDefinition;
            else
                Procedures.Add(procedureDefinition.ProcedureUri, procedureDefinition);

            return this;
        }

        /// <summary>
        /// Method called before incoming WAMP message will be handled.
        /// </summary>
        /// <param name="messageContext">Context wrapper object for incoming WAMP message</param>
        protected virtual void OnMessageHandling(MessageContext messageContext) { }

        /// <summary>
        /// Method called after incoming WAMP message has been handled.
        /// </summary>
        /// <param name="messageContext">Context wrapper object for incoming WAMP message</param>
        protected virtual void OnMessageHandled(MessageContext messageContext) { }

        /// <summary>
        /// Sets new WAMP message handler.
        /// </summary>
        /// <param name="msgType"></param>
        /// <param name="handler"></param>
        public void SetMessageHandler(MessageTypes msgType, IMessageHandler handler)
        {
            if (Handlers.ContainsKey(msgType))
                Handlers[msgType] = handler;
            else
                Handlers.Add(msgType, handler);
        }

        /// <summary>
        /// Explicitly creates a new WAMP Pub/Sub topic.
        /// </summary>
        /// <param name="topicUri">Fully qualiffied URI used as unique <see cref="Topic"/> identifier</param>
        public void CreateTopic(string topicUri)
        {
            Topics.AddTopic(topicUri, true);
        }

        /// <summary>
        /// Explicitly removes an existing WAMP Pub/Sub topic.
        /// </summary>
        /// <param name="topicUri">Fully qualiffied URI used as unique <see cref="Topic"/> identifier</param>
        /// <returns>True if topic existed and was removed successfully.</returns>
        public bool RemoveTopic(string topicUri)
        {
            var topic = Topics[topicUri];
            if (topic != null)
            {
                return Topics.RemoveTopic(topicUri);
            }
            return false;
        }

        /// <summary>
        /// Method called when new JSON message has incommed.
        /// </summary>
        /// <param name="sender">WAMP session for client sending a message</param>
        /// <param name="json">JSON string</param>
        protected void ReceiveJson(IWampSession sender, string json)
        {
            var message = MessageProvider.DeserializeMessage(json);
            if (message != null)
            {
                OnMessageReceived(sender, message);
            }
        }

        /// <summary>
        /// Method handler for incoming WAMP messages.
        /// </summary>
        /// <param name="sender">WAMP session for client sending a message</param>
        /// <param name="message">Incoming WAMP message</param>
        protected virtual void OnMessageReceived(IWampSession sender, IMessage message)
        {
            var messageContext = CreateMessageContext(message, sender);
            IMessageHandler handler;
            OnMessageHandling(messageContext);

            if (!messageContext.Cancel && Handlers.TryGetValue(message.Type, out handler))
            {
                handler.Handle(messageContext);
                OnMessageHandled(messageContext);
            }
        }

        /// <summary>
        /// Creates a new <see cref="MessageContext"/> for incoming WAMP message.
        /// </summary>
        /// <param name="message">Incoming WAMP message</param>
        /// <param name="sender">WAMP session for client sending a message</param>
        /// <returns>A new instance of message wrapper context</returns>
        protected virtual MessageContext CreateMessageContext(IMessage message, IWampSession sender)
        {
            return new MessageContext
                       {
                           Message = message,
                           SenderSession = sender,
                           Procedures = Procedures,
                           Response = ResponseQueue,
                           Topics = Topics,
                           Scheduler = Scheduler
                       };
        }

        /// <summary>
        /// Method called when new WAMP client has connected.
        /// </summary>
        /// <param name="connection">Object representing connected WAMP client</param>
        protected virtual void OnConnected(IWampConnection connection)
        {
            var session = InitializeWampSession(connection);
            var welcomeMessage = new WelcomeMessage(session.SessionId, WampConstants.ProtocolVersion, WampConstants.ServerIdentifier);
            var json = MessageProvider.SerializeMessage(welcomeMessage);

            session.Connection.Send(json);
        }

        /// <summary>
        /// Method called when existing WAMP client has been disconnected.
        /// </summary>
        /// <param name="session">Existing WAMP session associated with connected WAMP client</param>
        protected virtual void OnDisconnected(IWampSession session)
        {
            Sessions.RemoveSession(session.SessionId);
        }

        /// <summary>
        /// Initializes a new WAMP session for provided client connection
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        protected virtual IWampSession InitializeWampSession(IWampConnection connection)
        {
            var session = new WampSession(connection);
            Sessions.AddSession(session);

            return session;
        }

        /// <summary>
        /// Converts provided procedure URI into absolute form.
        /// </summary>
        /// <param name="procUri">Absolute or relative uri string</param>
        /// <returns></returns>
        private Uri GetProcedureUri(Uri procUri)
        {
            return procUri.IsAbsoluteUri
                       ? procUri
                       : new Uri(AddressUri, procUri);
        }

        /// <summary>
        /// Gets new message from top of the response queue and sends it.
        /// </summary>
        private void SendMessages()
        {
            while (true)
            {
                var incoming = ResponseQueue.Receive();
                var session = Sessions.GetSession(incoming.Item1);
                var json = MessageProvider.SerializeMessage(incoming.Item2);
                
                session.Connection.Send(json);
            }
        }
    }
}
