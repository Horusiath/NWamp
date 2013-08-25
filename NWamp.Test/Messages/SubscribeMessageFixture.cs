using FluentAssertions;
using NUnit.Framework;
using NWamp.Messages;
using System;

namespace NWamp.Test.Messages
{
    [TestFixture]
    public class SubscribeMessageFixture
    {
        private SubscribeMessage message;
        private readonly string topicUri = "http://sample.org/major#minor";

        [SetUp]
        public void Init()
        {
            message = new SubscribeMessage(topicUri);
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
        }

        [Test]
        public void array_serialization_serializes_all_properties_in_correct_order()
        {
            var array = message.ToArray();

            array.Length.Should().Be(2);
            array[0].Should().Be(MessageTypes.Subscribe);
            array[1].Should().Be(topicUri);
        }
    }
}
