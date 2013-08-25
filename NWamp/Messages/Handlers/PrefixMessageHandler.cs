namespace NWamp.Messages.Handlers
{
    /// <summary>
    /// Message handler for <see cref="PrefixMessage"/> class objects. 
    /// </summary>
    public class PrefixMessageHandler : IMessageHandler
    {
        /// <summary>
        /// Declares a CURIE->URI prefix mapping for prefix message sender.
        /// </summary>
        /// <param name="messageContext">Context wrapper object for incoming WAMP message</param>
        public virtual void Handle(MessageContext messageContext)
        {
            var message = messageContext.Message as PrefixMessage;
            if (message != null)
            {
                messageContext.SenderSession.Prefixes.SetPrefix(message.Prefix, message.Uri);
            }
        }
    }
}
