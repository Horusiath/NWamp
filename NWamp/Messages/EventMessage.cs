using System.Diagnostics;

namespace NWamp.Messages
{
    /// <summary>
    /// Message class sent to subscribers of PubSub events created by publisher with <see cref="PublishMessage"/> objects.
    /// </summary>
    [DebuggerDisplay("[{Type}, \"{TopicUri}\", \"{EventObject}\"]")]
    public class EventMessage : IMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventMessage"/> class.
        /// </summary>
        /// <remarks>Use this for serialization only.</remarks>
        public EventMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventMessage"/> class.
        /// </summary>
        /// <param name="topicUri">Fully qualified URI for the topic</param>
        /// <param name="eventObject">Event object payload</param>
        public EventMessage(string topicUri, object eventObject)
        {
            TopicUri = topicUri;
            EventObject = eventObject;
        }

        /// <summary>
        /// Gets type of this message: <see cref="MessageTypes.Event"/>.
        /// </summary>
        public MessageTypes Type { get { return MessageTypes.Event; } }

        /// <summary>
        /// Gets or sets fully qualified URI for the topic.
        /// </summary>
        public string TopicUri { get; set; }

        /// <summary>
        /// Gets or sets the event object payload
        /// </summary>
        public object EventObject { get; set; }

        /// <summary>
        /// Parses current message to array of objects, ready to serialize it directly into WAMP message frame.
        /// </summary>
        public object[] ToArray()
        {
            return new[] {MessageTypes.Event, TopicUri, EventObject};
        }
    }
}
