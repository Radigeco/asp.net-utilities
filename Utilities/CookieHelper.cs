using System;
using System.Web;

namespace Utilities
{
    /// <summary>
    /// Set of functions which help when dealing with ASP.NET cookies
    /// </summary>
    public static class CookieHelper
    {
        /// <summary>
        /// Removes given cookie
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <param name="name"></param>
        public static void RemoveCookie(HttpRequestBase request, HttpResponseBase response, string name)
        {
            if (request.Cookies[name] != null)
            {

                var c = new HttpCookie(name)
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                response.Cookies.Add(c);
            }
        }

        /// <summary>
        /// Removes all cookies
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public static void RemoveAllCookies(HttpRequestBase request, HttpResponseBase response)
        {
            foreach (var cookieName in request.Cookies.AllKeys)
            {
                var cookie = new HttpCookie(cookieName)
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                response.Cookies.Add(cookie);
            }
        }
    }
}