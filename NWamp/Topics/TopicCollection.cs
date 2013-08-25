using System.Collections.Generic;

namespace NWamp.Topics
{
    /// <summary>
    /// Class container for <see cref="Topic"/> instances.
    /// </summary>
    public class TopicCollection : IEnumerable<Topic>
    {
        /// <summary>
        /// Collection of currently active topics, accessible by topic URI identifiers.
        /// </summary>
        private readonly IDictionary<string, Topic> _topics;

        /// <summary>
        /// Gets a topic identified by provided <paramref name="key"/> or null, 
        /// if topic with that key doesn't exists.
        /// </summary>
        /// <param name="key"><see cref="Topic"/> URI identifier.</param>
        /// <returns></returns>
        public Topic this[string key]
        {
            get
            {
                Topic topic;
                return _topics.TryGetValue(key, out topic)
                    ? topic
                    : null;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TopicCollection"/> class.
        /// </summary>
        public TopicCollection()
        {
            _topics = new Dictionary<string, Topic>();
        }

        /// <summary> 
        /// Initializes a new instance of the <see cref="TopicCollection"/> class 
        /// with collection of predefined <paramref name="topics"/>.
        /// </summary>
        /// <param name="topics"></param>
        public TopicCollection(IEnumerable<Topic> topics)
        {
            _topics = new Dictionary<string, Topic>();
            foreach (var topic in topics)
            {
                _topics.Add(topic.Id, topic);
            }
        }

        /// <summary>
        /// Returns topic with provided URI identifier, optionaly 
        /// initializes it inside a collection if it didn't exist.
        /// </summary>
        /// <param name="topicId"><see cref="Topic"/> URI identifier</param>
        /// <param name="isFixed">Value determining if topic should be fixed or created/destroyed on demand</param>
        /// <returns></returns>
        public Topic AddTopic(string topicId, bool isFixed = false)
        {
            Topic topic;
            if (!_topics.TryGetValue(topicId, out topic))
            {
                topic = new Topic(topicId, isFixed);
                _topics.Add(topicId, topic);
            }
            else
                topic.IsFixed = isFixed;

            return topic;
        }

        /// <summary>
        /// Removes <see cref="Topic"/> identifier by provided URI identifier.
        /// </summary>
        /// <param name="topicId"><see cref="Topic"/> URI identifier</param>
        /// <returns></returns>
        public bool RemoveTopic(string topicId)
        {
            return _topics.Remove(topicId);
        }

        /// <summary>
        /// Checks if current collection contains <see cref="Topic"/> with provided URI identifier.
        /// </summary>
        /// <param name="topicId"><see cref="Topic"/> URI identifier</param>
        /// <returns></returns>
        public bool ContainsId(string topicId)
        {
            return _topics.ContainsKey(topicId);
        }

        public IEnumerator<Topic> GetEnumerator()
        {
            return _topics.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
