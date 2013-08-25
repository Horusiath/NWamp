using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using FluentAssertions;
using NWamp.Messages;
using NWamp.Messages.Handlers;
using NWamp.Rpc;

namespace NWamp.Test.MessageHandlers
{
    [TestFixture]
    public class CallMessageHandlerFixture
    {
        private CallMessageHandler handler;
        private Mock<IProcedureScheduler> schedulerMock;

        private readonly string sessionId = "ASAP1223_3";
        private readonly string procUri = "http://sample.org/major#minor";
        private readonly string callId = "adsas_aDDD1";

        [SetUp]
        public void Init()
        {
            handler = new CallMessageHandler();
            schedulerMock = new Mock<IProcedureScheduler>();
        }

        [Test]
        public void schedules_procedure_call_when_defined()
        {
            schedulerMock.Setup(scheduler => scheduler.Schedule(It.IsAny<ProcedureContext>())).Verifiable();
            var context = new MessageContext
            {
                Procedures = new Dictionary<Uri, ProcedureDefinition> { { new Uri(procUri), new ProcedureDefinition(procUri, null) } },
                Scheduler = schedulerMock.Object,
                Message = new CallMessage(callId, procUri)
            };

            handler.Handle(context);

            schedulerMock.Verify(scheduler => scheduler.Schedule(It.IsAny<ProcedureContext>()), Times.Once());
        }

        [Test]
        public void doesnt_schedule_procedure_doesnt_call_when_not_defined()
        {
            schedulerMock.Setup(scheduler => scheduler.Schedule(It.IsAny<ProcedureContext>())).Verifiable();
            var context = new MessageContext
            {
                Procedures = new Dictionary<Uri, ProcedureDefinition> { },
                Scheduler = schedulerMock.Object,
                Message = new CallMessage(callId, procUri)
            };

            handler.Handle(context);

            schedulerMock.Verify(scheduler => scheduler.Schedule(It.IsAny<ProcedureContext>()), Times.Never());
        }
    }
}
