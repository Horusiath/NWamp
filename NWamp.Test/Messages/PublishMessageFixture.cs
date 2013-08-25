using System;
using FluentAssertions;
using NWamp.Messages;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NWamp.Test.Messages
{
    [TestFixture]
    public class PublishMessageFixture
    {
        private readonly string topicUri = "http://sample.org/major#minor";
        private readonly object eventObj = new { Event = new object() };
        private readonly bool excludeSelf = true;
        private readonly IEnumerable<string> excludes = new[] { "A", "B", "C" };
        private readonly IEnumerable<string> eligibles = new[] { "D", "E", "F" };

        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void message_type_implements_IMessage_interface()
        {
            var message = new PublishMessage();
            (message is IMessage).Should().BeTrue();
        }

        [Test]
        public void parametrized_constructor_for_all_recepients_should_assign_all_parameters()
        {
            var message = new PublishMessage(topicUri, eventObj);

            message.TopicUri.Should().Be(topicUri);
            message.EventObject.Should().Be(eventObj);
            message.ExcludeSelf.Should().BeFalse();
            message.Eligibles.Should().BeNull();
            message.Excludes.Should().BeNull();
        }

        [Test]
        public void parametrized_constructor_with_self_exclude_should_assign_all_parameters()
        {
            var message = new PublishMessage(topicUri, eventObj, excludeSelf);

            message.TopicUri.Should().Be(topicUri);
            message.EventObject.Should().Be(eventObj);
            message.ExcludeSelf.Should().BeTrue();
            message.Eligibles.Should().BeNull();
            message.Excludes.Should().BeNull();
        }

        [Test]
        public void parametrized_constructor_with_excludes_and_eligibles_should_assign_all_parameters()
        {
            var message = new PublishMessage(topicUri, eventObj, excludes, eligibles);

            message.TopicUri.Should().Be(topicUri);
            message.EventObject.Should().Be(eventObj);
            message.ExcludeSelf.Should().BeFalse();
            message.Eligibles.Should().BeEquivalentTo(eligibles);
            message.Excludes.Should().BeEquivalentTo(excludes);
        }

        [Test]
        public void array_serialization_for_all_recepients_serializes_all_properties_in_correct_order()
        {
            var message = new PublishMessage(topicUri, eventObj);
            var array = message.ToArray();
            array.Length.Should().Be(3);

            array[0].Should().Be(MessageTypes.Publish);
            array[1].Should().Be(topicUri);
            array[2].Should().Be(eventObj);
        }

        [Test]
        public void array_serialization_with_self_exclude_serializes_all_properties_in_correct_order()
        {
            var message = new PublishMessage(topicUri, eventObj, excludeSelf);
            var array = message.ToArray();
            array.Length.Should().Be(4);

            array[0].Should().Be(MessageTypes.Publish);
            array[1].Should().Be(topicUri);
            array[2].Should().Be(eventObj);
            array[3].Should().Be(excludeSelf);
        }

        [Test]
        public void array_serialization_with_excludes_serializes_all_properties_in_correct_order()
        {
            var message = new PublishMessage(topicUri, eventObj, excludes, null);
            var array = message.ToArray();
            array.Length.Should().Be(4);

            array[0].Should().Be(MessageTypes.Publish);
            array[1].Should().Be(topicUri);
            array[2].Should().Be(eventObj);
            (array[3] as IEnumerable<string>).Should().BeEquivalentTo(excludes);
        }

        [Test]
        public void array_serialization_with_eligibles_serializes_all_properties_in_correct_order()
        {
            var message = new PublishMessage(topicUri, eventObj, null, eligibles);
            var array = message.ToArray();
            array.Length.Should().Be(5);

            array[0].Should().Be(MessageTypes.Publish);
            array[1].Should().Be(topicUri);
            array[2].Should().Be(eventObj);
            (array[3] as IEnumerable<string>).Should().BeEquivalentTo(Enumerable.Empty<string>());
            (array[4] as IEnumerable<string>).Should().BeEquivalentTo(eligibles);
        }
    }
}
