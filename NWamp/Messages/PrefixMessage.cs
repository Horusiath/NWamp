using System;
using System.Diagnostics;

namespace NWamp.Messages
{
    /// <summary>
    /// Message class used to define CURIE->URI mapping for target client. Each mapping is unique for WAMP client.
    /// </summary>
    /// <remarks>
    ///     Both procedures (and errors) in RPC and topics in PubSub are identified using URIs or CURIEs. 
    ///     Whenever a URI is used, full identification of the procedure/topic is provided by this URI. 
    ///     However, URIs can get long, which means tedious to input for developers, and also resulting in 
    ///     considerable volume on wire, when many small messages are exchanged.
    /// 
    ///     To counter that, URIs MAY be abbreviated using the CURIE (Compact URI Expression) syntax. 
    ///     For example, the (full) URI:
    /// 
    ///         http://example.com/simple/calc#square
    /// 
    ///     may be abbreviated as
    /// 
    ///         calc:square
    /// 
    ///     when it was previously agreed that the prefix calc is meant to stand for
    /// 
    ///         http://example.com/simple/calc#
    /// 
    /// </remarks>
    [DebuggerDisplay("[{Type}, \"{Prefix}\", \"{Uri}\"]")]
    public class PrefixMessage : IMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrefixMessage"/> class.
        /// </summary>
        /// <remarks>Use this constructor for serialization only.</remarks>
        public PrefixMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrefixMessage"/> class.
        /// </summary>
        /// <param name="prefix">CURIE prefix</param>
        /// <param name="uri">Fully qualified URI string</param>
        public PrefixMessage(string prefix, string uri)
        {
            Prefix = prefix;
            Uri = uri;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrefixMessage"/> class.
        /// </summary>
        /// <param name="prefix">CURIE prefix</param>
        /// <param name="uri">Fully qualified URI</param>
        public PrefixMessage(string prefix, Uri uri)
        {
            Prefix = prefix;
            Uri = uri.ToString();
        }

        /// <summary>
        /// Gets type of this message: <see cref="MessageTypes.Prefix"/>.
        /// </summary>
        public MessageTypes Type { get { return MessageTypes.Prefix; } }

        /// <summary>
        /// Gets or sets a CURIE prefix for mapping.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets fully qualified URI string for mapping.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Parses current message to array of objects, ready to serialize it directly into WAMP message frame.
        /// </summary>
        public object[] ToArray()
        {
            return new object[] { MessageTypes.Prefix, Prefix, Uri };
        }
    }
}
