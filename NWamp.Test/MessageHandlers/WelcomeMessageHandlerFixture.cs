using NUnit.Framework;
using NWamp.Messages.Handlers;
using NWamp.Messages;
using FluentAssertions;
using Moq;
using NWamp.Transport;

namespace NWamp.Test.MessageHandlers
{
    [TestFixture]
    public class WelcomeMessageHandlerFixture
    {
        private WelcomeMessageHandler handler;
        private Mock<MessageContext> contextMock;

        private readonly string sessionId = "ASAP1223_3";

        [SetUp]
        public void Init()
        {
            contextMock = new Mock<MessageContext>();
            handler = new WelcomeMessageHandler();
        }

        [Test]
        public void throws_exception_on_protocol_version_older()
        {
            var context = new MessageContext { Message = new WelcomeMessage { ProtocolVersion = 0 } };
            Assert.Throws(typeof(ProtocolVersionException), () => handler.Handle(context));
        }

        [Test]
        public void doesnt_throw_exception_on_protocol_version_newer()
        {
            var context = new MessageContext
            {
                Message = new WelcomeMessage { ProtocolVersion = 2 },
                SenderSession = new WampSession(null)
            };
            Assert.DoesNotThrow(() => handler.Handle(context));
        }

        [Test]
        public void sets_sender_session_id()
        {
            var context = new MessageContext
            {
                Message = new WelcomeMessage(sessionId, 1, "NWamp/1.0"),
                SenderSession = new WampSession(null)
            };
            handler.Handle(context);

            context.SenderSession.SessionId.Should().Be(sessionId);
        }
    }
}
