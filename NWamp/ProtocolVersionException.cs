namespace NWamp
{
    /// <summary>
    /// Exception thrown when incompatibile WAMP versions of client and server has occurred.
    /// </summary>
    public class ProtocolVersionException : WampException
    {
        public double VersionRequired { get; private set; }

        public ProtocolVersionException(string message, double verisonRequired)
            : base(message)
        {
            VersionRequired = verisonRequired;
        }
    }
}
