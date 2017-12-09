using System;
using System.Text;

namespace Utilities
{
    /// <summary>
    /// Set of functions which help when dealing with JWT tokens
    /// </summary>
    public static class JwtHelper
    { 
        /// <summary>
        /// Returns the header part of a JWT token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string GetHeader(string token)
        {
            string segment = token.Split('.')[0];
            return DecodeSegment(segment);
        }

        /// <summary>
        /// Returns the payload part of a JWT token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string GetPayload(string token)
        {
            string segment = token.Split('.')[1];
            return DecodeSegment(segment);
        }

        /// <summary>
        /// Returns the signature part of a JWT token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string GetSignature(string token)
        {
            string segment = token.Split('.')[2];
            return DecodeSegment(segment);
        }

        /// <summary>
        /// Decodes a given segment of a JWT token
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        private static string DecodeSegment(string segment)
        {
            segment = Base64Helper.FixLength(segment);
            byte[] data = Convert.FromBase64String(segment);
            string decodedString = Encoding.UTF8.GetString(data).ToLower();
            return decodedString;
        }
    }

}