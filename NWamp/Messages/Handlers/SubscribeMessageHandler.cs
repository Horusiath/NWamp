namespace NWamp.Messages.Handlers
{
    /// <summary>
    /// Message handler for <see cref="SubscribeMessage"/> class objects. 
    /// </summary>
    public class SubscribeMessageHandler : IMessageHandler
    {
        /// <summary>
        /// Handles incoming WAMP <see cref="SubscribeMessage"/>,
        /// subscribing message sender to target WAMP topic, or creating one if topic didn't exists yet.
        /// </summary>
        /// <param name="messageContext">Context wrapper object for incoming WAMP message</param>
        public virtual void Handle(MessageContext messageContext)
        {
            var message = messageContext.Message as SubscribeMessage;
            if (message != null)
            {
                var topic = messageContext.Topics.AddTopic(message.TopicUri);
                topic.Subscribers.Add(messageContext.SenderSession.SessionId);
            }
        }
    }
}
