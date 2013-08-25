using System;

namespace NWamp.Transport
{
    /// <summary>
    /// Class used for generation of WAMP session identifiers.
    /// </summary>
    public static class IdGenerator
    {
        /// <summary>
        /// Value randomizer.
        /// </summary>
        private static readonly Random Rand = new Random();

        /// <summary>
        /// Collection of chars used to generate session identifier string.
        /// </summary>
        private static readonly string alphas =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890_-";

        /// <summary>
        /// Creates new session identifier.
        /// </summary>
        /// <param name="size">Session key length.</param>
        public static string GenerateSessionId(int size = 16)
        {
            var chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = alphas[Rand.Next(alphas.Length)];
            }
            return new string(chars);
        }
    }
}
