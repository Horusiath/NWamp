using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NWamp
{
    /// <summary>
    /// Common interface for all WAMP client implementations.
    /// </summary>
    public interface IWampClient : IDisposable
    {
        /// <summary>
        /// Gets value determining if client is connected to any WAMP host.
        /// </summary>
        bool IsConnected { get; }
        
        /// <summary>
        /// Get collection of prefixes defined for current client.
        /// </summary>
        IEnumerable<KeyValuePair<string, string>> Prefixes { get; }

        /// <summary>
        /// Initializes the connection with target WAMP host.
        /// </summary>
        /// <param name="address">Endpoint address of target WAMP host</param>
        void Connect(string address);

        /// <summary>
        /// Defines a new CURIE->URI mapping in scope of current WAMP session.
        /// </summary>
        void Prefix(string curie, string uri);

        /// <summary>
        /// Subscribes current client to topic identified by URI
        /// </summary>
        /// <param name="topicUri">Well formed URI or CURIE identifier of target topic</param>
        void Subscribe(string topicUri);

        /// <summary>
        /// Unsubscribes current client from topic identified by URI
        /// </summary>
        /// <param name="topicUri">Well formed URI or CURIE identifier of target topic</param>
        void Unsubscribe(string topicUri);

        /// <summary>
        /// Publishes provided <paramref name="eventObject"/> instance between all subscribers of target topic.
        /// </summary>
        /// <param name="topicUri">Well formed URI or CURIE identifier of target topic</param>
        /// <param name="eventObject">Object to publish in topic scope</param>
        /// <param name="excludeSelf">Should message be abstained from sender</param>
        void Publish(string topicUri, object eventObject, bool excludeSelf = false);

        /// <summary>
        /// Publishes provided <paramref name="eventObject"/> instance between all subscribers of target topic.
        /// </summary>
        /// <param name="topicUri">Well formed URI or CURIE identifier of target topic</param>
        /// <param name="eventObject">Object to publish in topic scope</param>
        /// <param name="eligibleSessions">Explicit collections of receivers sessions</param>
        void PublishTo(string topicUri, object eventObject, IEnumerable<string> eligibleSessions);

        /// <summary>
        /// Publishes provided <paramref name="eventObject"/> instance between all subscribers of target topic.
        /// </summary>
        /// <param name="topicUri">Well formed URI or CURIE identifier of target topic</param>
        /// <param name="eventObject">Object to publish in topic scope</param>
        /// <param name="excludeSessions">Explicit collections of excluded topic subscribers</param>
        void PublishExcept(string topicUri, object eventObject, IEnumerable<string> excludeSessions);

        /// <summary>
        /// Asynchronous remote procedure call.
        /// </summary>
        /// <typeparam name="TResult">Type of object returned from remote procedure</typeparam>
        /// <param name="procUri">URI or CURIE identifier of the remote procedure</param>
        /// <param name="arguments">Additional arguments passed to procedure</param>
        /// <returns>Object returned by remote procedure</returns>
        Task<TResult> CallAsync<TResult>(string procUri, params object[] arguments);
    }
}
