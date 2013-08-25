using System.Diagnostics;

namespace NWamp.Messages
{
    /// <summary>
    /// Message class used to subscribe client to Pub/Sub topic.
    /// </summary>
    [DebuggerDisplay("[{Type}, \"{TopicUri}\"]")]
    public class SubscribeMessage : IMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscribeMessage"/> class.
        /// </summary>
        /// <remarks>Use this constructor for serialization only.</remarks>
        public SubscribeMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscribeMessage"/> class.
        /// </summary>
        /// <param name="topicUri">URI or CURIE identifying Pub/Sub topic</param>
        public SubscribeMessage(string topicUri)
        {
            TopicUri = topicUri;
        }

        /// <summary>
        /// Gets type of this message: <see cref="MessageTypes.Subscribe"/>.
        /// </summary>
        public MessageTypes Type { get { return MessageTypes.Subscribe; } }

        /// <summary>
        /// Gets or sets URI or CURIE identifying Pub/Sub topic, message sender want subscribe to.
        /// </summary>
        public string TopicUri { get; set; }

        /// <summary>
        /// Parses current message to array of objects, ready to serialize it directly into WAMP message frame.
        /// </summary>
        public object[] ToArray()
        {
            return new object[] { MessageTypes.Subscribe, TopicUri };
        }
    }
}
