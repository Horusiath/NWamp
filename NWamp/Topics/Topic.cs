using System.Collections.Generic;

namespace NWamp.Topics
{
    /// <summary>
    /// Class representing single Pub/Sub topic.
    /// </summary>
    public class Topic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Topic"/> class.
        /// </summary>
        /// <param name="id">Fully qualified URI identifying created topic</param>
        /// <param name="isFixed">Optional parameters determining if topic should be fixed or created/destroyed on demand</param>
        public Topic(string id, bool isFixed = false)
        {
            Id = id;
            IsFixed = isFixed;
            Subscribers = new HashSet<string>();
        }

        /// <summary>
        /// Gets or sets fully qualified URI identifying current topic.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets value determining if topic should be fixed or created/destroyed on demand.
        /// </summary>
        public bool IsFixed { get; set; }

        /// <summary>
        /// Gets or sets collection of subscribers sessions identifiers.
        /// </summary>
        public ICollection<string> Subscribers { get; set; }
    }
}
