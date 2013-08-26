using System;

namespace NWamp.Rpc
{
    /// <summary>
    /// Class defining remote procedure, which could be called using WAMP RPC mechanism.
    /// </summary>
    public class ProcedureDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcedureDefinition"/> class.
        /// </summary>
        /// <param name="procUri">URI identifier of a remote procedure</param>
        /// <param name="procedureCall">Handler delegate for .NET wrapper method to be invoked directly on incoming RPC</param>
        public ProcedureDefinition(string procUri, Func<object[], object> procedureCall)
        {
            ProcedureCall = procedureCall;
            ProcedureUri = procUri;
        }

        /// <summary>
        /// Gets or sets fully qualified RPC URI string
        /// </summary>
        public string ProcedureUri { get; set; }

        /// <summary>
        /// Gets or sets handler delegate for .NET wrapper method invoking registered remote procedure.
        /// </summary>
        public Func<object[],object> ProcedureCall { get; set; }

        /// <summary>
        /// Gets or sets collection defining types of each of the RPC arguments.
        /// </summary>
        public Type[] ArgumentTypes { get; set; }

        /// <summary>
        /// Gets or sets type of object returned by RPC, when it finishes successfully.
        /// </summary>
        public Type ResponseType { get; set; }
    }
}
