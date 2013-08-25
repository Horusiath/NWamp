namespace NWamp.Messages
{
    /// <summary>
    /// Enum of WAMP message type codes.
    /// </summary>
    public enum MessageTypes
    {
        /// <summary>
        /// Welcome message send by server to initialize WAMP session.
        /// </summary>
        Welcome = 0,

        /// <summary>
        /// Prefix message send by client to define CURIE->URI mapping.
        /// </summary>
        Prefix = 1,

        /// <summary>
        /// Call message send by client to initialize the remote procedure call.
        /// </summary>
        Call = 2,

        /// <summary>
        /// Call result message send by server to return a remote 
        /// procedure call result if procedure finished successfully.
        /// </summary>
        CallResult = 3,

        /// <summary>
        /// Call error message send by server to return information about 
        /// remote procedure not found or exception occurence during RPC.
        /// </summary>
        CallError = 4,

        /// <summary>
        /// Subscribe message send by client to subscribe it to Pub/Sub topic.
        /// </summary>
        Subscribe = 5,

        /// <summary>
        /// Unsubscribe message send by client to unsubscribe it from subscribed Pub/Sub topic.
        /// </summary>
        Unsubscribe = 6,
        
        /// <summary>
        /// Publish message send by client to distribute event message in scope of Pub/Sub topic.
        /// </summary>
        Publish = 7,

        /// <summary>
        /// Event message send by server on client publish 
        /// message request to client subscribed to Pub/Sub topic.
        /// </summary>
        Event = 8
    }
}
