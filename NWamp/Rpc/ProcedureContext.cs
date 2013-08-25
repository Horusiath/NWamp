using NWamp.Transport;

namespace NWamp.Rpc
{
    /// <summary>
    /// Context class for scheduled RPC.
    /// </summary>
    public class ProcedureContext
    {
        /// <summary>
        /// Gets or sets requested remote procedure call identifier.
        /// </summary>
        public string CallId { get; set; }

        /// <summary>
        /// Gets or sets requested remote procedure call requester client session.
        /// </summary>
        public IWampSession RequesterSession { get; set; }

        /// <summary>
        /// Gets or sets definition of the procedure to be called.
        /// </summary>
        public ProcedureDefinition ProcedureDefinition { get; set; }

        /// <summary>
        /// Gets or sets arguments lists to be passed to called procedure.
        /// </summary>
        public object[] Arguments { get; set; }
    }
}
