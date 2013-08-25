using System.Diagnostics;

namespace NWamp.Messages
{
    /// <summary>
    /// Error message class returned to client when remote procedure call could not be 
    /// executed or exception occured during execution of remote procedure.
    /// </summary>
    [DebuggerDisplay("[{Type}, \"{CallId}\", \"{ErrorUri}\", \"{ErrorDescription}\", {ErrorDetails}]")]
    public class CallErrorMessage : IMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallErrorMessage"/> class.
        /// </summary>
        /// <remarks>Use this constructor for serialization only.</remarks>
        public CallErrorMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallErrorMessage"/> class.
        /// </summary>
        /// <param name="callId">Unique identifier of remote procedure call</param>
        /// <param name="errorUri">URI or CURIE string identifying an error</param>
        /// <param name="errorDescription">Human readable description of error</param>
        /// <param name="errorDetails">Application error details, defined by <paramref name="errorUri"/></param>
        public CallErrorMessage(string callId, string errorUri, string errorDescription, object errorDetails = null)
        {
            CallId = callId;
            ErrorUri = errorUri;
            ErrorDescription = errorDescription;
            ErrorDetails = errorDetails;
        }

        /// <summary>
        /// Gets type of this message: <see cref="MessageTypes.CallError"/>.
        /// </summary>
        public MessageTypes Type { get { return MessageTypes.CallError; } }

        /// <summary>
        /// Gets or sets an unique identifier of remote procedure call.
        /// </summary>
        public string CallId { get; set; }

        /// <summary>
        /// Gets or sets an URI or CURIE string identifying an error
        /// </summary>
        public string ErrorUri { get; set; }

        /// <summary>
        /// Gets or sets a human readable description of error.
        /// </summary>
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Gets or sets an application error details, defined by <see cref="ErrorUri"/>.
        /// </summary>
        public object ErrorDetails { get; set; }

        /// <summary>
        /// Parses current message to array of objects, ready to serialize it directly into WAMP message frame.
        /// </summary>
        /// <returns></returns>
        public object[] ToArray()
        {
            var array = new object[ErrorDetails == null ? 4 : 5];
            array[0] = MessageTypes.CallError;
            array[1] = CallId;
            array[2] = ErrorUri;
            array[3] = ErrorDescription;

            if (ErrorDetails != null) array[4] = ErrorDetails;

            return array;
        }
    }
}
