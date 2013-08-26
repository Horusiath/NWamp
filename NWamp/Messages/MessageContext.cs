using System;
using NWamp.Rpc;
using NWamp.Topics;
using NWamp.Transport;
using System.Collections.Generic;

namespace NWamp.Messages
{
    /// <summary>
    /// Class context for incoming WAMP message frames.
    /// </summary>
    public class MessageContext
    {
        /// <summary>
        /// Gets or sets value determining, if message handling should be canceled.
        /// </summary>
        public bool Cancel { get; set; }

        /// <summary>
        /// Gets or sets WAMP host address.
        /// </summary>
        public string HostAddress { get; set; }

        /// <summary>
        /// Gets or sets the incoming <see cref="IMessage"/> instance.
        /// </summary>
        public IMessage Message { get; set; }

        /// <summary>
        /// Gets or sets the procedure sheduler used for invoking procedure calls in asynchronous manner.
        /// </summary>
        public IProcedureScheduler Scheduler { get; set; }

        /// <summary>
        /// Gets or sets session object associated with a sender of the <see cref="Message"/>.
        /// </summary>
        public IWampSession SenderSession { get; set; }

        /// <summary>
        /// Gets or sets response queue, allowing to send response messages to other WAMP clients.
        /// </summary>
        public IResponseQueue Response { get; set; }

        /// <summary>
        /// Gets or sets collection of current active topics.
        /// </summary>
        public TopicCollection Topics { get; set; }

        /// <summary>
        /// Gets or sets collection of defined procedures, which could be called using RPC.
        /// </summary>
        public IDictionary<string, ProcedureDefinition> Procedures { get; set; }
    }
}
