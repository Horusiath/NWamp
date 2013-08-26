using NWamp.Messages;
using NWamp.Transport;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace NWamp.Rpc
{
    /// <summary>
    /// Implementation of <see cref="IProcedureScheduler"/>, responsible for managing remote procedure calls.
    /// </summary>
    public class ProcedureScheduler : IProcedureScheduler
    {
        /// <summary>
        /// Response queue used for passing results received from invoked RPC.
        /// </summary>
        protected IResponseQueue Response;

        /// <summary>
        /// Type resolver used for converting deserialized JSON object into specific type instances.
        /// </summary>
        protected ITypeResolver TypeResolver;

        /// <summary>
        /// Collection of <see cref="Task"/> objects, handling RPC which are currently executing.
        /// </summary>
        protected ConcurrentDictionary<string, Task> Tasks;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcedureScheduler"/> class.
        /// </summary>
        /// <param name="responseQueue">Response queue used for sending RPC results back to client</param>
        /// <param name="typeResolver">Resolver used for converting deserialized JSON object into specific type instances</param>
        public ProcedureScheduler(IResponseQueue responseQueue, ITypeResolver typeResolver)
        {
            Response = responseQueue;
            TypeResolver = typeResolver;
            Tasks = new ConcurrentDictionary<string, Task>();
        }

        /// <summary>
        /// Schedules new RPC request.
        /// </summary>
        /// <param name="context"></param>
        public void Schedule(ProcedureContext context)
        {
            ResolveProcedureArgumentsTypes(context);

            var callId = context.CallId;
            var handler = CreateProcedureHandler(context);
            var task = new Task(handler);

            if (Tasks.TryAdd(callId, task))
            {
                task.Start();
                task.ContinueWith(t =>
                {
                    Task outTask;
                    Tasks.TryRemove(callId, out outTask);
                });
            }
        }

        /// <summary>
        /// Returns a delegate used for handling RPC invoke flow, 
        /// including handling exception and returning WAMP result messages.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected virtual Action CreateProcedureHandler(ProcedureContext context)
        {
            Action action = () =>
                {
                    IMessage message;
                    try
                    {
                        var func = context.ProcedureDefinition.ProcedureCall;
                        var args = context.Arguments;
                        var result = func(args);

                        message = CreateResultMessage(context, result);
                    }
                    catch (Exception e)
                    {
                        message = CreateErrorMessage(context, e);
                    }
                    Response.Send(context.RequesterSession.SessionId, message);
                };

            return action;
        }

        /// <summary>
        /// Creates a new instance of <see cref="CallResultMessage"/> class.
        /// </summary>
        /// <param name="context">Context of RPC request</param>
        /// <param name="result">Result of successfull RPC exection</param>
        /// <returns></returns>
        protected virtual CallResultMessage CreateResultMessage(ProcedureContext context, object result)
        {
            return new CallResultMessage(context.CallId, result);
        }

        /// <summary>
        /// Creates a new instance of <see cref="CallErrorMessage"/> class.
        /// </summary>
        /// <param name="context">Context of RPC request</param>
        /// <param name="exception">Exception, which ocurred during RPC exection</param>
        /// <returns></returns>
        protected virtual CallErrorMessage CreateErrorMessage(ProcedureContext context, Exception exception)
        {
            return new CallErrorMessage(context.CallId, string.Empty, exception.Message);
        }

        /// <summary>
        /// Converts provided procedure call arguments into destinated types.
        /// </summary>
        /// <param name="context"></param>
        protected virtual void ResolveProcedureArgumentsTypes(ProcedureContext context)
        {
            for (int i = 0; i < context.Arguments.Length; i++)
            {
                var argType = context.ProcedureDefinition.ArgumentTypes[i];
                var destinationObject = TypeResolver.Resolve(context.Arguments[i], argType);
                context.Arguments[i] = destinationObject;
            }
        }
    }
}
