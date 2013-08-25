namespace NWamp.Rpc
{
    /// <summary>
    /// Procedure scheduler interface used for scheduling requested remote procedure calls.
    /// </summary>
    public interface IProcedureScheduler
    {
        /// <summary>
        /// Schedules new RPC request.
        /// </summary>
        /// <param name="context"></param>
        void Schedule(ProcedureContext context);
    }
}
