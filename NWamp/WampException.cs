using System;

namespace NWamp
{
    /// <summary>
    /// Common WAMP exception class.
    /// </summary>
    public class WampException : Exception
    {
        public WampException():base()
        {
        }

        public WampException(string msgFormat, params object[] args)
            :base(string.Format(msgFormat, args))
        {
        }

        public  WampException(string msg, Exception innerException):base(msg, innerException)
        {
        }
    }
}
