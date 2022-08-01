using System.Text.RegularExpressions;

namespace Fengchao.Gallery.Core.Text
{
    /// <summary>
    /// Provides extension methods for <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// In a specified input string, replaces all strings that match a specified regular expression with
        /// a specified replacement string. Specified options modify the matching operation.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="replacement">The replacement string.</param>
        /// <returns>
        /// A new string that is identical to the input string, except that the replacement string
        /// takes the place of each matched string. If pattern is not matched in the current instance,
        /// the method returns the current instance unchanged.</returns>
        public static string ReplaceWithRegex(this string input, string? pattern, string? replacement)
        {
            return Regex.Replace(input, pattern, replacement);
        }

        /// <summary>
        /// In a specified input string, replaces all strings that match a specified regular expression with
        /// a specified replacement string based on a predicate if the judgement is matched. Specified options
        /// modify the matching operation.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="judgement">The judgement to decide whether the replacement should take affect.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="replacement">The replacement string.</param>
        /// <returns>
        /// A new string that is identical to the input string, except that the replacement string
        /// takes the place of each matched string. If pattern is not matched in the current instance,
        /// the method returns the current instance unchanged.</returns>
        public static string ReplaceWithRegexIf(this string input, bool judgement, string? pattern, string? replacement)
        {
            return judgement
                ? Regex.Replace(input, pattern, replacement)
                : input;
        }
    }
}
