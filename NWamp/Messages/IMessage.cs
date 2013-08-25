namespace NWamp.Messages
{
    /// <summary>
    /// Common interface for all WAMP message frames.
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Gets type of the WAMP message.
        /// </summary>
        MessageTypes Type { get; }

        /// <summary>
        /// Parses current message to array of objects, ready to serialize it directly into WAMP message frame.
        /// </summary>
        object[] ToArray();
    }
}
