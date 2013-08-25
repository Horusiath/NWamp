namespace NWamp
{
    /// <summary>
    /// Container for general WAMP environment contants.
    /// </summary>
    public static class WampConstants
    {
        /// <summary>
        /// Gets number of WAMP protocol version.
        /// </summary>
        public static int ProtocolVersion { get { return 1; } }

        /// <summary>
        /// Gets string identifier of current NWamp procotol implementation.
        /// </summary>
        public static string ServerIdentifier { get { return "NWamp/0.2-beta"; } }
    }
}
