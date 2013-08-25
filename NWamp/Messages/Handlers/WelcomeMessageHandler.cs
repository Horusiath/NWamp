namespace NWamp.Messages.Handlers
{
    /// <summary>
    /// Message handler for <see cref="WelcomeMessage"/> class objects. 
    /// </summary>
    public class WelcomeMessageHandler : IMessageHandler
    {
        /// <summary>
        /// Handles incoming WAMP <see cref="WelcomeMessage"/>,
        /// initializing a new WAMP session on the client side.
        /// </summary>
        /// <param name="messageContext">Context wrapper object for incoming WAMP message</param>
        public void Handle(MessageContext messageContext)
        {
            var message = messageContext.Message as WelcomeMessage;
            if (message != null)
            {
                EnsureProtocolVersion(message);

                messageContext.SenderSession.SessionId = message.SessionId;
            }
        }

        /// <summary>
        /// Ensures that both client and server speaks in compatibile WAMP protocol versions.
        /// </summary>
        /// <param name="message">WAMP session initialization message sent by server</param>
        private void EnsureProtocolVersion(WelcomeMessage message)
        {
            var cmpResult = message.ProtocolVersion.CompareTo(WampConstants.ProtocolVersion);
            if(cmpResult == -1)
                throw new ProtocolVersionException("Current library WAMP protocol version is outdated", message.ProtocolVersion);
        }
    }
}
