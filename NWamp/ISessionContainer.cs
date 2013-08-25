using NWamp.Transport;
using System.Collections.Generic;

namespace NWamp
{
    /// <summary>
    /// Interface representing server container for active WAMP sessions.
    /// </summary>
    public interface ISessionContainer : IEnumerable<IWampSession>
    {
        /// <summary>
        /// Stores new WAMP session.
        /// </summary>
        void AddSession(IWampSession session);

        /// <summary>
        /// Removes existing WAMP session.
        /// </summary>
        void RemoveSession(string sessionId);

        /// <summary>
        /// Returns a WAMP session identified by provided <paramref name="sessionId"/> 
        /// or null if no matching session has been found.
        /// </summary>
        IWampSession GetSession(string sessionId);
    }
}
