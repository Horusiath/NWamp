using System;
using System.Collections.Generic;

namespace NWamp
{
    /// <summary>
    /// Prefix map class used for storing and resolving CURIE->URI mappings.
    /// </summary>
    public class PrefixMap
    {
        private readonly IDictionary<string, string> _mappings;

        private string _defaultUri;

        /// <summary>
        /// Gets or sets efault uri returned when no requested prefix match.
        /// Available only when FaultTolerant is set to true.
        /// </summary>
        public string DefaultUri
        {
            get { return _defaultUri; }
            set
            {
                if (!Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute))
                    throw new UriFormatException("Uri parameter is not well formed uri string");

                _defaultUri = value;
            }
        }

        /// <summary>
        /// Flag determining behavior for non prefix matches.
        /// When set to true, DefaultUri will be returned.
        /// When set to false, exception will be thrown.
        /// </summary>
        public bool FaultTolerant { get; set; }

        /// <summary>
        /// Creates new instance of <see cref="PrefixMap"/>.
        /// </summary>
        public PrefixMap()
        {
            _mappings = new Dictionary<string, string>();
        }

        /// <summary>
        /// Creates new instance of <see cref="PrefixMap"/>.
        /// </summary>
        /// <param name="mappings"></param>
        public PrefixMap(IEnumerable<KeyValuePair<string, string>> mappings)
        {
            _mappings = new Dictionary<string, string>();

            if (mappings != null)
                foreach (var mapping in mappings)
                {
                    SetPrefix(mapping.Key, mapping.Value);
                }
        }

        /// <summary>
        /// Creates new instance of <see cref="PrefixMap"/>.
        /// </summary>
        public PrefixMap(IEnumerable<KeyValuePair<string, string>> mappings, string defaulUri)
            : this(mappings)
        {
            if (!Uri.IsWellFormedUriString(defaulUri, UriKind.RelativeOrAbsolute))
                throw new UriFormatException("Uri parameter is not well formed uri string");

            FaultTolerant = true;
            DefaultUri = defaulUri;
        }

        /// <summary>
        /// Set new URI for provided prefix value.
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="uri">String in URI format.</param>
        /// <returns>
        /// True if new mapping has been created.
        /// False if existing prefix has been overrided.
        /// </returns>
        public bool SetPrefix(string prefix, string uri)
        {
            if (!Uri.IsWellFormedUriString(uri, UriKind.RelativeOrAbsolute))
                throw new UriFormatException("Uri parameter is not well formed uri string");

            if (_mappings.ContainsKey(prefix))
            {
                _mappings[prefix] = uri;
                return false;
            }
            _mappings.Add(prefix, uri);
            return true;
        }

        /// <summary>
        /// Removes mapping associated with target prefix.
        /// </summary>
        public void RemovePrefix(string prefixOrUri)
        {
            if (!Uri.IsWellFormedUriString(prefixOrUri, UriKind.RelativeOrAbsolute))
            {
                var keyToRemove = string.Empty;
                foreach (KeyValuePair<string, string> mapping in _mappings)
                {
                    if (mapping.Value == prefixOrUri)
                        keyToRemove = mapping.Key;
                }
                if (!string.IsNullOrEmpty(keyToRemove))
                    _mappings.Remove(keyToRemove);
            }
            else
            {
                _mappings.Remove(prefixOrUri);
            }
        }

        /// <summary>
        /// Maps given value into Uri available inside the mappings.
        /// </summary>
        public string Map(string prefixOrUri)
        {
            if (_mappings.ContainsKey(prefixOrUri))
                return _mappings[prefixOrUri];

            if (Uri.IsWellFormedUriString(prefixOrUri, UriKind.RelativeOrAbsolute))
                return prefixOrUri;

            if (FaultTolerant)
                return DefaultUri;

            throw new WampPrefixException("No matching prefix has been found.");
        }

        /// <summary>
        /// Checks if target prefix mapping exists inside the mapper.
        /// This method will not check if direct Uri mapping exists.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public bool ContainsPrefix(string prefix)
        {
            return _mappings.ContainsKey(prefix);
        }

        /// <summary>
        /// Checks if target mapping exists inside the mapper.
        /// </summary>
        public bool ContainsMapping(string prefixOrUri)
        {
            if (Uri.IsWellFormedUriString(prefixOrUri, UriKind.RelativeOrAbsolute))
                return true;

            return _mappings.ContainsKey(prefixOrUri);
        }
    }
}
