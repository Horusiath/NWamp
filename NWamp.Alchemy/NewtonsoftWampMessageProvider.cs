using System;
using System.Collections.Generic;
using NWamp.Messages;
using Newtonsoft.Json;

namespace NWamp
{
    /// <summary>
    /// Implementation of <see cref="IMessageProvider"/> interface using JSON.NET converters.
    /// </summary>
    public class NewtonsoftWampMessageProvider : IMessageProvider
    {
        private readonly IDictionary<MessageTypes, Func<object[], IMessage>> _builders =
            new Dictionary<MessageTypes, Func<object[], IMessage>>
        {
            {MessageTypes.Prefix, CreatePrefixMessage },
            {MessageTypes.Call, CreateCallMessage },
            {MessageTypes.Publish, CreatePublishMessage },
            {MessageTypes.Subscribe, CreateSubscribeMessage },
            {MessageTypes.Unsubscribe, CreateUnsubscribeMessage }
        };

        public IMessage DeserializeMessage(string json)
        {
            try
            {
                var array = JsonConvert.DeserializeObject<object[]>(json);
                return CreateMessage(array);
            }
            catch (Exception exc)
            {
            }

            return null;
        }

        public string SerializeMessage(IMessage message)
        {
            var array = message.ToArray();
            return JsonConvert.SerializeObject(array);
        }

        protected IMessage CreateMessage(object[] array)
        {
            var msgTypeNum = Convert.ToInt32(array[0]);
            var builder = _builders[(MessageTypes)msgTypeNum];

            return builder(array);
        }

        private static PrefixMessage CreatePrefixMessage(object[] array)
        {
            return new PrefixMessage(array[1].ToString(), array[2].ToString());
        }

        private static PublishMessage CreatePublishMessage(object[] array)
        {
            switch(array.Length)
            {
                case 3: return new PublishMessage(array[1].ToString(), array[2]);
                case 4: return new PublishMessage(array[1].ToString(), array[2], Convert.ToBoolean(array[3]));
                case 5: return new PublishMessage(array[1].ToString(), array[2], As<IEnumerable<string>>(array[3]), As<IEnumerable<string>>(array[4]));
                default: throw new MessageParsingException("PublishMessage: incompatibile number of message frame array elements");
            }
        }

        private static SubscribeMessage CreateSubscribeMessage(object[] array)
        {
            return new SubscribeMessage(array[1].ToString());
        }

        private static UnsubscribeMessage CreateUnsubscribeMessage(object[] array)
        {
            return new UnsubscribeMessage(array[1].ToString());
        }

        private static CallMessage CreateCallMessage(object[] array)
        {
            var arglist = new object[array.Length - 3];
            for (int i = 3; i < array.Length; i++)
            {
                arglist[i - 3] = array[i];
            }

            return new CallMessage(array[1].ToString(), array[2].ToString(), arglist);
        }

        private static TResult As<TResult>(object o)
        {
            return (TResult) o;
        }
    }
}
