namespace NWamp.Messages
{
    /// <summary>
    /// Interface of the message provider, allowing for WAMP message frame serialization/deserialization.
    /// </summary>
    public interface IMessageProvider
    {
        /// <summary>
        /// Deserializes a JSON string into WAMP message frame.
        /// </summary>
        /// <param name="json">JSON string containing incoming WAMP message</param>
        /// <returns>Deserialized WAMP message frame</returns>
        IMessage DeserializeMessage(string json);

        /// <summary>
        /// Serializes a WAMP message frame into a JSON string.
        /// </summary>
        /// <param name="message">Message frame to serialize</param>
        /// <returns>JSON string</returns>
        string SerializeMessage(IMessage message);
    }
}
