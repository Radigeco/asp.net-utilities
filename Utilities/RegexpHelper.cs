using System.Text.RegularExpressions;

namespace Utilities
{
    /// <summary>
    /// Set of functions which help when dealing with Regular expressions
    /// </summary>
    public class RegexpHelper
    {
        /// <summary>
        /// Replaces given word in a sentence 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static string ReplaceText(string input, string pattern, string replacement)
        {
            Regex regexp = new Regex(pattern);
            return regexp.Replace(input, replacement);
        }
    }
}