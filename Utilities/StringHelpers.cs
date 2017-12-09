using System;

namespace Utilities
{
    public class StringHelpers
    {
        public static string ToCamelCase(string inputSentence)
        {
            // If there are 0 or 1 characters, just return the string.
            if (inputSentence == null || inputSentence.Length < 2)
                return inputSentence;

            // Split the string into words.
            string[] words = inputSentence.Split(
                new char[] { },
                StringSplitOptions.RemoveEmptyEntries);

            // Combine the words.
            string camelCasedSentence = words[0].ToLower();
            for (int i = 1; i < words.Length; i++)
            {
                camelCasedSentence +=
                    words[i].Substring(0, 1).ToUpper() +
                    words[i].Substring(1);
            }

            return camelCasedSentence;
        }
    }
}
