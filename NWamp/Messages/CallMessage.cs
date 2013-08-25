using System.Diagnostics;

namespace NWamp.Messages
{
    /// <summary>
    /// Message class sent by client to server, used for intializing a RPC call.
    /// </summary>
    [DebuggerDisplay("[{Type}, \"{CallId}\", \"{ProcUri}\", \"{Arguments}\"]")]
    public class CallMessage : IMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallMessage"/> class.
        /// </summary>
        /// <remarks>Use this constructor for serialization only.</remarks>
        public CallMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallMessage"/> class.
        /// </summary>
        /// <param name="callId">Unique identifier of remote procedure call</param>
        /// <param name="procUri">URI or CURIE of the remote procedure to be called</param>
        /// <param name="args">Remote procedure call arguments</param>
        public CallMessage(string callId, string procUri, params object[] args)
        {
            CallId = callId;
            ProcUri = procUri;
            Arguments = args;
        }

        /// <summary>
        /// Gets type of this message: <see cref="MessageTypes.Call"/>.
        /// </summary>
        public MessageTypes Type { get { return MessageTypes.Call; } }

        /// <summary>
        /// Gets or sets an unique identifier of remote procedure call.
        /// </summary>
        public string CallId { get; set; }

        /// <summary>
        /// Gets or sets URI or CURIE of the remote procedure to be called.
        /// </summary>
        public string ProcUri { get; set; }

        /// <summary>
        /// Gets or sets the remote procedure call arguments.
        /// </summary>
        public object[] Arguments { get; set; }

        /// <summary>
        /// Parses current message to array of objects, ready to serialize it directly into WAMP message frame.
        /// </summary>
        public object[] ToArray()
        {
            var array = new object[Arguments.Length + 3];
            array[0] = MessageTypes.Call;
            array[1] = CallId;
            array[2] = ProcUri;

            for (int i = 0; i < Arguments.Length; i++)
            {
                array[i + 3] = Arguments[i];
            }

            return array;
        }
    }

    public class CallMessage<T1> : CallMessage
    {
        public CallMessage(string callId, string procUri, T1 arg)
            : base(callId, procUri, new object[] { arg })
        {
        }

        public T1 Arg1 { get { return (T1)Arguments[0]; } set { Arguments[0] = value; } }
    }

    public class CallMessage<T1, T2> : CallMessage
    {
        public CallMessage(string callId, string procUri, T1 arg1, T2 arg2)
            : base(callId, procUri, new object[] { arg1, arg2 })
        {
        }

        public T1 Arg1 { get { return (T1)Arguments[0]; } set { Arguments[0] = value; } }
        public T2 Arg2 { get { return (T2)Arguments[1]; } set { Arguments[1] = value; } }
    }

    public class CallMessage<T1, T2, T3> : CallMessage
    {
        public CallMessage(string callId, string procUri, T1 arg1, T2 arg2, T3 arg3)
            : base(callId, procUri, new object[] { arg1, arg2, arg3 })
        {
        }

        public T1 Arg1 { get { return (T1)Arguments[0]; } set { Arguments[0] = value; } }
        public T2 Arg2 { get { return (T2)Arguments[1]; } set { Arguments[1] = value; } }
        public T3 Arg3 { get { return (T3)Arguments[2]; } set { Arguments[2] = value; } }
    }

    public class CallMessage<T1, T2, T3, T4> : CallMessage
    {
        public CallMessage(string callId, string procUri, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            : base(callId, procUri, new object[] { arg1, arg2, arg3, arg4 })
        {
        }

        public T1 Arg1 { get { return (T1)Arguments[0]; } set { Arguments[0] = value; } }
        public T2 Arg2 { get { return (T2)Arguments[1]; } set { Arguments[1] = value; } }
        public T3 Arg3 { get { return (T3)Arguments[2]; } set { Arguments[2] = value; } }
        public T4 Arg4 { get { return (T4)Arguments[3]; } set { Arguments[3] = value; } }
    }

    public class CallMessage<T1, T2, T3, T4, T5> : CallMessage
    {
        public CallMessage(string callId, string procUri, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            : base(callId, procUri, new object[] { arg1, arg2, arg3, arg4, arg5 })
        {
        }

        public T1 Arg1 { get { return (T1)Arguments[0]; } set { Arguments[0] = value; } }
        public T2 Arg2 { get { return (T2)Arguments[1]; } set { Arguments[1] = value; } }
        public T3 Arg3 { get { return (T3)Arguments[2]; } set { Arguments[2] = value; } }
        public T4 Arg4 { get { return (T4)Arguments[3]; } set { Arguments[3] = value; } }
        public T5 Arg5 { get { return (T5)Arguments[4]; } set { Arguments[4] = value; } }
    }

    public class CallMessage<T1, T2, T3, T4, T5, T6> : CallMessage
    {
        public CallMessage(string callId, string procUri, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            : base(callId, procUri, new object[] { arg1, arg2, arg3, arg4, arg5, arg6 })
        {
        }

        public T1 Arg1 { get { return (T1)Arguments[0]; } set { Arguments[0] = value; } }
        public T2 Arg2 { get { return (T2)Arguments[1]; } set { Arguments[1] = value; } }
        public T3 Arg3 { get { return (T3)Arguments[2]; } set { Arguments[2] = value; } }
        public T4 Arg4 { get { return (T4)Arguments[3]; } set { Arguments[3] = value; } }
        public T5 Arg5 { get { return (T5)Arguments[4]; } set { Arguments[4] = value; } }
        public T6 Arg6 { get { return (T6)Arguments[5]; } set { Arguments[5] = value; } }
    }

    public class CallMessage<T1, T2, T3, T4, T5, T6, T7> : CallMessage
    {
        public CallMessage(string callId, string procUri, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            : base(callId, procUri, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 })
        {
        }

        public T1 Arg1 { get { return (T1)Arguments[0]; } set { Arguments[0] = value; } }
        public T2 Arg2 { get { return (T2)Arguments[1]; } set { Arguments[1] = value; } }
        public T3 Arg3 { get { return (T3)Arguments[2]; } set { Arguments[2] = value; } }
        public T4 Arg4 { get { return (T4)Arguments[3]; } set { Arguments[3] = value; } }
        public T5 Arg5 { get { return (T5)Arguments[4]; } set { Arguments[4] = value; } }
        public T6 Arg6 { get { return (T6)Arguments[5]; } set { Arguments[5] = value; } }
        public T7 Arg7 { get { return (T7)Arguments[6]; } set { Arguments[6] = value; } }
    }

    public class CallMessage<T1, T2, T3, T4, T5, T6, T7, T8> : CallMessage
    {
        public CallMessage(string callId, string procUri, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            : base(callId, procUri, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 })
        {
        }

        public T1 Arg1 { get { return (T1)Arguments[0]; } set { Arguments[0] = value; } }
        public T2 Arg2 { get { return (T2)Arguments[1]; } set { Arguments[1] = value; } }
        public T3 Arg3 { get { return (T3)Arguments[2]; } set { Arguments[2] = value; } }
        public T4 Arg4 { get { return (T4)Arguments[3]; } set { Arguments[3] = value; } }
        public T5 Arg5 { get { return (T5)Arguments[4]; } set { Arguments[4] = value; } }
        public T6 Arg6 { get { return (T6)Arguments[5]; } set { Arguments[5] = value; } }
        public T7 Arg7 { get { return (T7)Arguments[6]; } set { Arguments[6] = value; } }
        public T8 Arg8 { get { return (T8)Arguments[7]; } set { Arguments[7] = value; } }
    }
}
