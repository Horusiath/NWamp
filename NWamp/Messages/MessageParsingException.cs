using System;

namespace NWamp.Messages
{
    /// <summary>
    /// Exception thrown when WAMP message parsing failed.
    /// </summary>
    public class MessageParsingException : WampException
    {
        public MessageParsingException(string message):base(message)
        {
        }

        public MessageParsingException(string message, Exception innerException):base(message, innerException)
        {
        }
    }
}
