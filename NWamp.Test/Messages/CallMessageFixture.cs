using System;
using FluentAssertions;
using NWamp.Messages;
using NUnit.Framework;

namespace NWamp.Test.Messages
{
    [TestFixture]
    public class CallMessageFixture
    {
        private CallMessage message;
        private readonly string procUri = "major:minor";
        private readonly string callId = "ABCDEFG123";
        private readonly object arg1 = new DateTime(1980, 10, 1);
        private readonly object arg2 = "arg2";

        [SetUp]
        public void Init()
        {
            message = new CallMessage(callId, procUri, arg1, arg2);
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
            message.ProcUri.Should().Be(procUri);

            message.Arguments.Length.Should().Be(2);
            message.Arguments[0].Should().Be(arg1);
            message.Arguments[1].Should().Be(arg2);
        }
        
        [Test]
        public void array_serialization_serializes_all_properties_in_correct_order()
        {
            var array = message.ToArray();
            array.Length.Should().Be(5);

            array[0].Should().Be(MessageTypes.Call);
            array[1].Should().Be(callId);
            array[2].Should().Be(procUri);
            array[3].Should().Be(arg1);
            array[4].Should().Be(arg2);
        }
    }
}
