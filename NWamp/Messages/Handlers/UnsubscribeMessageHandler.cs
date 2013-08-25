namespace NWamp.Messages.Handlers
{
    /// <summary>
    /// Message handler for <see cref="UnsubscribeMessage"/> class objects. 
    /// </summary>
    public class UnsubscribeMessageHandler : IMessageHandler
    {
        /// <summary>
        /// Handles incoming WAMP <see cref="UnsubscribeMessage"/>,
        /// unsubscribing message sender from target WAMP topic.
        /// </summary>
        /// <param name="messageContext">Context wrapper object for incoming WAMP message</param>
        public virtual void Handle(MessageContext messageContext)
        {
            var message = messageContext.Message as UnsubscribeMessage;
            if (message != null)
            {
                var topic = messageContext.Topics[message.TopicUri];
                if (topic != null)
                {
                    topic.Subscribers.Remove(messageContext.SenderSession.SessionId);

                    if (!topic.IsFixed && topic.Subscribers.Count == 0)
                        messageContext.Topics.RemoveTopic(message.TopicUri);
                }
            }
        }
    }
}
