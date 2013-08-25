namespace NWamp.Messages
{
    /// <summary>
    /// Static class used for easing creation of generic <see cref="CallMessage"/> instances.
    /// </summary>
    public static class CallMessages
    {
        public static CallMessage Create(string callId, string procUri)
        {
            return new CallMessage(callId, procUri);
        }

        public static CallMessage<T1> Create<T1>(string callId, string procUri, T1 arg1)
        {
            return new CallMessage<T1>(callId, procUri, arg1);
        }

        public static CallMessage<T1, T2> Create<T1, T2>(string callId, string procUri, T1 arg1, T2 arg2)
        {
            return new CallMessage<T1, T2>(callId, procUri, arg1, arg2);
        }

        public static CallMessage<T1, T2, T3> Create<T1, T2, T3>(string callId, string procUri, T1 arg1, T2 arg2, T3 arg3)
        {
            return new CallMessage<T1, T2, T3>(callId, procUri, arg1, arg2, arg3);
        }

        public static CallMessage<T1, T2, T3, T4> Create<T1, T2, T3, T4>(string callId, string procUri, 
            T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return new CallMessage<T1, T2, T3, T4>(callId, procUri, arg1, arg2, arg3, arg4);
        }

        public static CallMessage<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(string callId, string procUri,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return new CallMessage<T1, T2, T3, T4, T5>(callId, procUri, arg1, arg2, arg3, arg4, arg5);
        }

        public static CallMessage<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(string callId, string procUri,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            return new CallMessage<T1, T2, T3, T4, T5, T6>(callId, procUri, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static CallMessage<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(string callId, string procUri,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            return new CallMessage<T1, T2, T3, T4, T5, T6, T7>(callId, procUri, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static CallMessage<T1, T2, T3, T4, T5, T6, T7, T8> Create<T1, T2, T3, T4, T5, T6, T7, T8>(string callId, string procUri,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            return new CallMessage<T1, T2, T3, T4, T5, T6, T7, T8>(callId, procUri, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }
    }
}
