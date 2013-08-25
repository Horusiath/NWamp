using System.Diagnostics;

namespace NWamp.Messages
{
    /// <summary>
    /// Message class used to unsubscribe client to Pub/Sub topic.
    /// </summary>
    [DebuggerDisplay("[{Type}, \"{TopicUri}\"]")]
    public class UnsubscribeMessage : IMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnsubscribeMessage"/> class.
        /// </summary>
        /// <remarks>Use this constructor for serialization only.</remarks>
        public UnsubscribeMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnsubscribeMessage"/> class.
        /// </summary>
        /// <param name="topicUri">URI or CURIE identifying Pub/Sub topic</param>
        public UnsubscribeMessage(string topicUri)
        {
            TopicUri = topicUri;
        }

        /// <summary>
        /// Gets type of this message: <see cref="MessageTypes.Unsubscribe"/>.
        /// </summary>
        public MessageTypes Type { get { return MessageTypes.Unsubscribe; } }

        /// <summary>
        /// Gets or sets URI or CURIE identifying Pub/Sub topic, message sender want to unsubscribe from.
        /// </summary>
        public string TopicUri { get; set; }

        /// <summary>
        /// Parses current message to array of objects, ready to serialize it directly into WAMP message frame.
        /// </summary>
        public object[] ToArray()
        {
            return new object[] { MessageTypes.Unsubscribe, TopicUri };
        }
    }
}
