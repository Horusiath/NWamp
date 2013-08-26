using System;
using NWamp.Rpc;
using NWamp.Topics;

namespace NWamp
{
    /// <summary>
    /// Common interface for all WAMP host implementations.
    /// </summary>
    public interface IWampHost : IDisposable
    {
        /// <summary>
        /// Gets collection of topics existing in scope of current WAMP host.
        /// </summary>
        TopicCollection Topics { get; }

        /// <summary>
        /// Starts listening, waiting for incoming connections.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops listening.
        /// </summary>
        void Stop();

        /// <summary>
        /// Registers na new procedure to be callable using RPC mechanism.
        /// </summary>
        /// <param name="procedureDefinition">Definition of remote procedure</param>
        void RegisterProcedure(ProcedureDefinition procedureDefinition);

        /// <summary>
        /// Explicitly creates a new WAMP Pub/Sub topic.
        /// </summary>
        /// <param name="topicUri">Fully qualiffied URI used as unique <see cref="Topic"/> identifier</param>
        void CreateTopic(string topicUri);

        /// <summary>
        /// Explicitly removes an existing WAMP Pub/Sub topic.
        /// </summary>
        /// <param name="topicUri">Fully qualiffied URI used as unique <see cref="Topic"/> identifier</param>
        /// <returns>True if topic existed and was removed successfully.</returns>
        bool RemoveTopic(string topicUri);
    }
}
