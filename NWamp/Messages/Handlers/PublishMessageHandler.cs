using System.Collections.Generic;
using System.Linq;

namespace NWamp.Messages.Handlers
{
    /// <summary>
    /// Message handler for <see cref="PublishMessage"/> class objects. 
    /// </summary>
    public class PublishMessageHandler : IMessageHandler
    {
        /// <summary>
        /// Handles a WAMP <see cref="PublishMessage"/>, 
        /// distibuting event object among eligible susbscribers of WAMP topic.
        /// </summary>
        /// <param name="messageContext">Context wrapper object for incoming WAMP message</param>
        public virtual void Handle(MessageContext messageContext)
        {
            var message = messageContext.Message as PublishMessage;
            if (message != null)
            {
                var receivers = GetEligilbeSessions(messageContext);
                var eventMessage = new EventMessage(message.TopicUri, message.EventObject);

                foreach (var sessionId in receivers)
                {
                    messageContext.Response.Send(sessionId, eventMessage);
                }
            }
        }

        /// <summary>
        /// Returns collection of eligible topic subscribers sessions, to whom event object should be send.
        /// </summary>
        /// <param name="messageContext">Context wrapper object for incoming WAMP message</param>
        /// <returns></returns>
        protected virtual IEnumerable<string> GetEligilbeSessions(MessageContext messageContext)
        {
            var message = messageContext.Message as PublishMessage;
            if (message != null)
            {
                if (message.Eligibles != null && message.Eligibles.Any())
                    return message.Eligibles;

                var topic = messageContext.Topics[message.TopicUri];
                if (topic != null)
                {
                    IEnumerable<string> subscribers = topic.Subscribers;
                    if (message.Excludes != null && message.Excludes.Any())
                        subscribers = subscribers.Except(message.Excludes);
                    else if (message.ExcludeSelf)
                        subscribers = subscribers.Except(new[] { messageContext.SenderSession.SessionId });

                    return subscribers;
                }
            }
            return null;
        }
    }
}
