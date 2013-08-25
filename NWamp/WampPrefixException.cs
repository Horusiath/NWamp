namespace NWamp
{
    /// <summary>
    /// Exception thrown when no prefix mapping has been found.
    /// </summary>
    public class WampPrefixException : WampException
    {
        public WampPrefixException(string msg)
            : base(msg)
        {
        }
    }
}
