using System;
using System.Text;

namespace Utilities
{
    /// <summary>
    /// Set of functions which help when dealing with base64 encoding/decoding
    /// </summary>
    public static class Base64Helper
    {
        /// <summary>
        /// Fixes the padding bug
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string FixLength(string message)
        {
            int mod4 = message.Length % 4;
            if (mod4 > 0)
            {
                message += new string('=', 4 - mod4);
            }
            return message;
        }

        /// <summary>
        /// Decodes given message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string Base64Decode(string message)
        {
            message = FixLength(message);
            byte[] data = Convert.FromBase64String(message);
            string decodedMessage = Encoding.UTF8.GetString(data).ToLower();
            return decodedMessage;
        }

        /// <summary>
        /// Encodes given message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string Base64Encode(string message)
        {
            var encodedMessage = Convert.ToBase64String(message.ToByteArray());
            return encodedMessage;
        }
    }
}