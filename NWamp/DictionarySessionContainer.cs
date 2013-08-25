using System.Collections;
using System.Collections.Concurrent;
using NWamp.Transport;
using System.Collections.Generic;

namespace NWamp
{
    /// <summary>
    /// Default implementation of <see cref="ISessionContainer"/> interface.
    /// </summary>
    internal class DictionarySessionContainer : ISessionContainer
    {
        /// <summary>
        /// Internal dictionary used for storing WAMP sessions.
        /// </summary>
        private readonly IDictionary<string, IWampSession> _sessions = new ConcurrentDictionary<string, IWampSession>();

        /// <summary>
        /// Stores new WAMP session.
        /// </summary>
        /// <param name="session"></param>
        public void AddSession(IWampSession session)
        {
            _sessions.Add(session.SessionId, session);
        }

        /// <summary>
        /// Removes existing WAMP session.
        /// </summary>
        /// <param name="sessionId"></param>
        public void RemoveSession(string sessionId)
        {
            _sessions.Remove(sessionId);
        }

        /// <summary>
        /// Returns a WAMP session identified by provided <paramref name="sessionId"/> 
        /// or null if no matching session has been found.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public IWampSession GetSession(string sessionId)
        {
            IWampSession session;
            return _sessions.TryGetValue(sessionId, out session) ? session : null;
        }

        public IEnumerator<IWampSession> GetEnumerator()
        {
            return _sessions.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
