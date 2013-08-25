namespace NWamp.Messages.Handlers
{
    /// <summary>
    /// Common interface used for handling incoming WAMP <see cref="IMessage"/> frames.
    /// </summary>
    public interface IMessageHandler
    {
        /// <summary>
        /// Handles incoming WAMP message.
        /// </summary>
        /// <param name="messageContext">Context wrapper object for incoming WAMP message.</param>
        void Handle(MessageContext messageContext);
    }
}
