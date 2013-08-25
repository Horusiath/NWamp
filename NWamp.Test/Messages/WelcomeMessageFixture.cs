using System;
using FluentAssertions;
using NWamp.Messages;
using NUnit.Framework;

namespace NWamp.Test.Messages
{
    [TestFixture]
    public class WelcomeMessageFixture
    {
        private WelcomeMessage message;

        private readonly string sessionId = "ABCDEEG12345";
        private readonly int version = 1;
        private readonly string serverIdentifier = "NWamp/1.0";

        [SetUp]
        public void Init()
        {
            message = new WelcomeMessage(sessionId, version, serverIdentifier);
        }

        [Test]
        public void message_type_implements_IMessage_interface()
        {
            (message is IMessage).Should().BeTrue();
        }

        [Test]
        public void parametrized_constructor_assigns_all_variables()
        {
            message.SessionId.Should().Be(sessionId);
            message.ProtocolVersion.Should().Be(version);
            message.ServerIdentifier.Should().Be(serverIdentifier);
        }

        [Test]
        public void array_serialization_serializes_all_properties_in_correct_order()
        {
            var serializedArray = message.ToArray();

            serializedArray.Length.Should().Be(4);
            serializedArray[0].Should().Be(MessageTypes.Welcome);
            serializedArray[1].Should().Be(sessionId);
            serializedArray[2].Should().Be(version);
            serializedArray[3].Should().Be(serverIdentifier);
        }
    }
}
