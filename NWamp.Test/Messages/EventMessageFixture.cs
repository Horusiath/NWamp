using System;
using FluentAssertions;
using NWamp.Messages;
using NUnit.Framework;

namespace NWamp.Test.Messages
{
    [TestFixture]
    public class EventMessageFixture
    {
        private EventMessage message;
        private readonly string topicUri = "http://sample.org/major#minor";
        private readonly object eventObj = new { Event = new object() };

        [SetUp]
        public void Init()
        {
            message = new EventMessage(topicUri, eventObj);
        }

        [Test]
        public void message_type_implements_IMessage_interface()
        {
            (message is IMessage).Should().BeTrue();
        }

        [Test]
        public void parametrized_constructor_should_assign_all_parameters()
        {
            message.TopicUri.Should().Be(topicUri);
            message.EventObject.Should().Be(eventObj);
        }

        [Test]
        public void array_serialization_serializes_all_properties_in_correct_order()
        {
            var array = message.ToArray();
            array.Length.Should().Be(3);

            array[0].Should().Be(MessageTypes.Event);
            array[1].Should().Be(topicUri);
            array[2].Should().Be(eventObj);
        }
    }
}
