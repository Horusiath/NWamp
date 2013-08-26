using System;
using NWamp.Rpc;
using NWamp.Transport;

namespace NWamp.Messages.Handlers
{
    /// <summary>
    /// Message handler for <see cref="CallMessage"/> class objects.
    /// </summary>
    public class CallMessageHandler : IMessageHandler
    {
        /// <summary>
        /// Handles an incoming <see cref="CallMessage"/> object, scheduling a remote procedure call.
        /// </summary>
        /// <param name="messageContext">Context wrapper object for incoming WAMP message</param>
        public virtual void Handle(MessageContext messageContext)
        {
            var message = messageContext.Message as CallMessage;
            
            if (message != null)
            {
                ProcedureDefinition procedureDefinition;
                if (messageContext.Procedures.TryGetValue(message.ProcUri, out procedureDefinition))
                {
                    var context = CreateProcedureContext(message, procedureDefinition, messageContext.SenderSession);
                    messageContext.Scheduler.Schedule(context);
                }
                else
                {
                    var errorUri = messageContext.HostAddress + "/Error#ProcedureNotFound";
                    var description = string.Format("No remote procedure for {0} URI has been found", message.ProcUri);
                    var callErrorMessage = new CallErrorMessage(message.CallId, errorUri, description);

                    messageContext.Response.Send(messageContext.SenderSession.SessionId, callErrorMessage);
                }
            }
        }

        /// <summary>
        /// Creates na new <see cref="ProcedureContext"/> object used to schedule remote procedure call.
        /// </summary>
        /// <param name="message">Call message used for RPC request</param>
        /// <param name="definition">Definition of procedure to be called</param>
        /// <param name="session">WAMP message sender session object</param>
        /// <returns></returns>
        public virtual ProcedureContext CreateProcedureContext(CallMessage message, ProcedureDefinition definition, IWampSession session)
        {
            var procedureContext = new ProcedureContext
                                       {
                                           Arguments = message.Arguments,
                                           CallId = message.CallId,
                                           ProcedureDefinition =  definition,
                                           RequesterSession = session
                                       };
            return procedureContext;
        }
    }
}
