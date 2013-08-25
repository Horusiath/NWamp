using System.Diagnostics;

namespace NWamp.Messages
{
    /// <summary>
    /// Message class, sent back to client when the execution of the remote procedure finishes successfully.
    /// </summary>
    [DebuggerDisplay("[{Type}, \"{CallId}\", \"{Result}\"]")]
    public class CallResultMessage : IMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallResultMessage"/> class.
        /// </summary>
        /// <remarks>Use this for serialization only.</remarks>
        public CallResultMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallResultMessage"/> class.
        /// </summary>
        /// <param name="callId">Unique identifier of remote procedure call</param>
        /// <param name="result">Result of the remote procedure call</param>
        public CallResultMessage(string callId, object result)
        {
            CallId = callId;
            Result = result;
        }

        /// <summary>
        /// Gets type of this message: <see cref="MessageTypes.CallResult"/>.
        /// </summary>
        public MessageTypes Type { get { return MessageTypes.CallResult; } }

        /// <summary>
        /// Gets or sets an unique identifier of remote procedure call.
        /// </summary>
        public string CallId { get; set; }

        /// <summary>
        /// Gets or sets result of the remote procedure call.
        /// </summary>
        public object Result { get; set; }

        /// <summary>
        /// Parses current message to array of objects, ready to serialize it directly into WAMP message frame.
        /// </summary>
        public object[] ToArray()
        {
            return new[] { MessageTypes.CallResult, CallId, Result };
        }
    }

    public class CallResultMessage<TResult> : CallResultMessage
    {
        public CallResultMessage()
        {
        }

        public CallResultMessage(string callId, TResult result)
            : base(callId, result)
        {
        }

        public TResult TypedResult { get { return (TResult)Result; } set { Result = value; } }
    }
}
