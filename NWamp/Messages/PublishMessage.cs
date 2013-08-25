using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NWamp.Messages
{
    /// <summary>
    /// Message class containing an event, which should be send to Pub/Sub topic subscribers.
    /// </summary>
    [DebuggerDisplay("[{Type}, \"{TopicUri}\", \"{EventObject}\"]")]
    public class PublishMessage : IMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PublishMessage"/> class.
        /// </summary>
        /// <remarks>Use this constructor for serialization only.</remarks>
        public PublishMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PublishMessage"/> class.
        /// </summary>
        /// <param name="topicUri">URI or CURIE identifying Pub/Sub topic</param>
        /// <param name="eventObject">Event object to publish</param>
        public PublishMessage(string topicUri, object eventObject)
        {
            TopicUri = topicUri;
            EventObject = eventObject;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PublishMessage"/> class.
        /// </summary>
        /// <param name="topicUri">URI or CURIE identifying Pub/Sub topic</param>
        /// <param name="eventObject">Event object to publish</param>
        /// <param name="excludeSelf">Flag determining if event publisher should not receive message, he/she sent</param>
        public PublishMessage(string topicUri, object eventObject, bool excludeSelf)
        {
            TopicUri = topicUri;
            EventObject = eventObject;
            ExcludeSelf = excludeSelf;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PublishMessage"/> class.
        /// </summary>
        /// <param name="topicUri">URI or CURIE identifying Pub/Sub topic</param>
        /// <param name="eventObject">Event object to publish</param>
        /// <param name="excludes">List of session identifiers for clients, who should not receive event object</param>
        /// <param name="eligibles">Explicit list of session identifiers for clients, who should receive event object</param>
        public PublishMessage(string topicUri, object eventObject, IEnumerable<string> excludes, IEnumerable<string> eligibles)
        {
            TopicUri = topicUri;
            EventObject = eventObject;
            Excludes = excludes;
            Eligibles = eligibles;
        }

        /// <summary>
        /// Gets type of this message: <see cref="MessageTypes.Publish"/>.
        /// </summary>
        public MessageTypes Type { get { return MessageTypes.Publish; } }

        /// <summary>
        /// Gets or sets URI or CURIE identifying Pub/Sub topic.
        /// </summary>
        public string TopicUri { get; set; }

        /// <summary>
        /// Gets or sets event object to publish.
        /// </summary>
        public object EventObject { get; set; }

        /// <summary>
        /// Gets or sets value determining if event publisher should not receive message, he/she sent.
        /// </summary>
        public bool ExcludeSelf { get; set; }

        /// <summary>
        /// Gets or sets list of session identifiers for clients, who should not receive event object.
        /// </summary>
        public IEnumerable<string> Excludes { get; set; }

        /// <summary>
        /// Gets or sets explicit list of session identifiers for clients, who should receive event object.
        /// </summary>
        public IEnumerable<string> Eligibles { get; set; }

        /// <summary>
        /// Parses current message to array of objects, ready to serialize it directly into WAMP message frame.
        /// </summary>
        public object[] ToArray()
        {
            int arrayLen;
            if (Eligibles != null)
                arrayLen = 5;
            else if (Excludes != null || ExcludeSelf == true)
                arrayLen = 4;
            else arrayLen = 3;

            var array = new object[arrayLen];
            array[0] = MessageTypes.Publish;
            array[1] = TopicUri;
            array[2] = EventObject;

            if (array.Length >= 4)
            {
                array[3] = ExcludeSelf ? (object) ExcludeSelf : (Excludes ?? Enumerable.Empty<string>()).ToArray();
            }

            if (array.Length == 5)
            {
                array[4] = (Eligibles ?? Enumerable.Empty<string>()).ToArray();
            }

            return array;
        }
    }
}
