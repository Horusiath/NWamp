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
                var procUri = new Uri(message.ProcUri, UriKind.RelativeOrAbsolute);
                if (messageContext.Procedures.TryGetValue(procUri, out procedureDefinition))
                {
                    var context = CreateProcedureContext(message, procedureDefinition, messageContext.SenderSession);
                    messageContext.Scheduler.Schedule(context);
                }
                else
                {
                    //TODO: when procedure for requested URI has not been found CallErrorMessage should be sent
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
