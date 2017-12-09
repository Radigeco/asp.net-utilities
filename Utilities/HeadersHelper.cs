using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http.Headers;

namespace Utilities
{
    /// <summary>
    /// Set of functions which help when dealing with HTTP headers
    /// </summary>
    public class HeadersHelper
    {
        /// <summary>
        /// Sets the given header
        /// </summary>
        /// <param name="headerKey"></param>
        /// <param name="headervalue"></param>
        /// <param name="headers"></param>
        public static void SetHeaders(string headerKey, string headervalue, HttpRequestHeaders headers)
        {
            headers.Add(headerKey, headervalue);
        }

        /// <summary>
        /// Gets the given header
        /// </summary>
        /// <param name="headerName"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static string GetHeader(string headerName, HttpRequestHeaders headers)
        {
            IEnumerable<string> headerValues;
            var value = string.Empty;
            var keyFound = headers.TryGetValues(headerName, out headerValues);
            if (keyFound)
            {
                value = headerValues.FirstOrDefault();
            }
            return value;
        }

        /// <summary>
        /// Gets the given header
        /// </summary>
        /// <param name="headerName"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static string GetHeader(string headerName, NameValueCollection headers)
        {
            var value = headers[headerName];
            if (value == null)
            {
                return String.Empty;
            }
            return value;
        }
    }
}