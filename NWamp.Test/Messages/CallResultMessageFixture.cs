using System;
using FluentAssertions;
using NWamp.Messages;
using NUnit.Framework;

namespace NWamp.Test.Messages
{
    [TestFixture]
    public class CallResultMessageFixture
    {
        private CallResultMessage message;
        private readonly string callId = "ABCDEFG123";
        private readonly object response = new { ResponseCode = "OK" };

        [SetUp]
        public void Init()
        {
            message = new CallResultMessage(callId, response);
        }

        [Test]
        public void message_type_implements_IMessage_interface()
        {
            (message is IMessage).Should().BeTrue();
        }

        [Test]
        public void parametrized_constructor_should_assign_all_parameters()
        {
            message.CallId.Should().Be(callId);
            message.Result.Should().Be(response);
        }

        [Test]
        public void array_serialization_serializes_all_properties_in_correct_order()
        {
            var array = message.ToArray();
            array.Length.Should().Be(3);

            array[0].Should().Be(MessageTypes.CallResult);
            array[1].Should().Be(callId);
            array[2].Should().Be(response);
        }
    }
}
