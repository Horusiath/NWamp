using System;
using FluentAssertions;
using NWamp.Messages;
using NUnit.Framework;

namespace NWamp.Test.Messages
{
    [TestFixture]
    public class PrefixMessageFixture
    {
        private PrefixMessage message;
        private readonly string curie = "major:minor";
        private readonly string stringUri = "http://sample.org/major#minor";
        private readonly Uri uri = new Uri("http://sample.org/major#minor");

        [SetUp]
        public void Init()
        {
            message = new PrefixMessage(curie, uri);
        }

        [Test]
        public void message_type_implements_IMessage_interface()
        {
            (message is IMessage).Should().BeTrue();
        }

        [Test]
        public void parametrized_constructor_should_assign_all_parameters()
        {
            message.Prefix.Should().Be(curie);
            message.Uri.Should().Be(stringUri);
        }
        
        [Test]
        public void array_serialization_serializes_all_properties_in_correct_order()
        {
            var array = message.ToArray();
            array.Length.Should().Be(3);
            array[0].Should().Be(MessageTypes.Prefix);
            array[1].Should().Be(curie);
            array[2].Should().Be(stringUri);
        }
    }
}
