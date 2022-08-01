using Fengchao.Gallery.Core.Text;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Fengchao.Gallery.Core.Json
{
    /// <summary>
    /// Provides extension methods for a better using of JSON.
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// Serializes the specified object to a JSON string.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>A JSON string representation of the object.</returns>
        public static string ToJsonString(this object obj)
        {
            return obj.ToJsonString(Formatting.None);
        }

        /// <summary>
        /// Serializes the specified object to a JSON string using formatting.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="formatting">Indicates how the output should be formatted.</param>
        /// <returns>A JSON string representation of the object.</returns>
        public static string ToJsonString(this object obj, Formatting formatting)
        {
            if (formatting == Formatting.None)
            {
                var indentedJson = JsonConvert.SerializeObject(obj, Formatting.Indented);
                var splits = indentedJson.Split(Environment.NewLine);

                return string.Join(' ', splits.Select(s => s.Trim()));
            }

            return JsonConvert.SerializeObject(obj, formatting);
        }

        /// <summary>
        /// Serializes the specified object to a JSON string.
        /// </summary>
        /// <param name="value">The object to serialize.</param>
        /// <param name="continueWithStringFormat">
        /// Sets to true if the result json string will be used for string formatting.
        /// </param>
        /// <returns>A JSON string representation of the object.</returns>
        public static string ToJsonString(this object value, bool continueWithStringFormat)
        {
            return value.ToJsonString(Formatting.None, continueWithStringFormat);
        }

        /// <summary>
        /// Serializes the specified object to a JSON string using formatting.
        /// </summary>
        /// <param name="value">The object to serialize.</param>
        /// <param name="formatting">Indicates how the output should be formatted.</param>
        /// <param name="continueWithStringFormat">
        /// Sets to true if the result json string will be used for string formatting.
        /// </param>
        /// <returns>A JSON string representation of the object.</returns>
        public static string ToJsonString(this object value, Formatting formatting, bool continueWithStringFormat)
        {
            if (!continueWithStringFormat)
            {
                return value.ToJsonString(formatting);
            }

            var jsonStringLines = value.ToJsonString(Formatting.Indented).Split(Environment.NewLine);

            for (int i = 0; i < jsonStringLines.Length; i++)
            {
                if (jsonStringLines[i] == null)
                {
                    continue;
                }

                jsonStringLines[i] = jsonStringLines[i]
                    .ReplaceWithRegex(@"(^[\s\t]*)\{|("":[\s\t]*)\{", "$1$2{{")
                    .ReplaceWithRegex(@"(^[\s\t]*)\}", "$1}}")
                    .ReplaceWithRegexIf(formatting == Formatting.None, @"^[\s\t]+", string.Empty);
            }

            return formatting == Formatting.None
                ? string.Join(" ", jsonStringLines)
                : string.Join(Environment.NewLine, jsonStringLines);
        }
    }
}
