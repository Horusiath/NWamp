using FluentAssertions;
using NWamp.Messages;
using NUnit.Framework;

namespace NWamp.Test.Messages
{
    [TestFixture]
    public class CallErrorMessageFixture
    {
        private readonly string errorUri = "major:minor";
        private readonly string callId = "ABCDEFG123";
        private readonly string errorDescription = "error description";
        private readonly object errorDetails = new { detail = "yolo" };

        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void message_type_implements_IMessage_interface()
        {
            var message = new CallErrorMessage();
            (message is IMessage).Should().BeTrue();
        }

        [Test]
        public void parametrized_constructor_with_details_should_assign_all_parameters()
        {
            var message = new CallErrorMessage(callId, errorUri, errorDescription, errorDetails);

            message.ErrorUri.Should().Be(errorUri);
            message.CallId.Should().Be(callId);
            message.ErrorDescription.Should().Be(errorDescription);
            message.ErrorDetails.Should().Be(errorDetails);
        }

        [Test]
        public void array_serialization_with_details_serializes_all_properties_in_correct_order()
        {
            var message = new CallErrorMessage(callId, errorUri, errorDescription, errorDetails);
            var array = message.ToArray();

            array.Length.Should().Be(5);
            array[0].Should().Be(MessageTypes.CallError);
            array[1].Should().Be(callId);
            array[2].Should().Be(errorUri);
            array[3].Should().Be(errorDescription);
            array[4].Should().Be(errorDetails);
        }

        [Test]
        public void parametrized_constructor_without_details_should_assign_all_parameters()
        {
            var message = new CallErrorMessage(callId, errorUri, errorDescription);

            message.ErrorUri.Should().Be(errorUri);
            message.CallId.Should().Be(callId);
            message.ErrorDescription.Should().Be(errorDescription);
            message.ErrorDetails.Should().BeNull();
        }

        [Test]
        public void array_serialization_without_details_serializes_all_properties_in_correct_order()
        {
            var message = new CallErrorMessage(callId, errorUri, errorDescription);
            var array = message.ToArray();

            array.Length.Should().Be(4);
            array[0].Should().Be(MessageTypes.CallError);
            array[1].Should().Be(callId);
            array[2].Should().Be(errorUri);
            array[3].Should().Be(errorDescription);
        }
    }
}
