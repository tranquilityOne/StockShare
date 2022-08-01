using System.Text;

namespace Fengchao.Gallery.Core.Text
{
    /// <summary>
    /// Provides extension methods for <see cref="StringBuilder"/>.
    /// </summary>
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Appends a copy of the specified string to this instance.
        /// </summary>
        /// <param name="stringBuilder">A <see cref="StringBuilder"/> instance.</param>
        /// <param name="judgement">The judgement to decide whether the given string should be appended.</param>
        /// <param name="value">The string to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public static StringBuilder AppendIf(this StringBuilder stringBuilder, bool judgement, string value)
        {
            return judgement ? stringBuilder.Append(value) : stringBuilder;
        }

        /// <summary>
        /// Appends a copy of the specified string followed by the default line terminator to the end of the current
        /// <see cref="StringBuilder"/> object.
        /// </summary>
        /// <param name="stringBuilder">A <see cref="StringBuilder"/> instance.</param>
        /// <param name="judgement">The judgement to decide whether the given string should be appended.</param>
        /// <param name="value">The string to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public static StringBuilder AppendLineIf(this StringBuilder stringBuilder, bool judgement, string value)
        {
            return judgement ? stringBuilder.AppendLine(value) : stringBuilder;
        }
    }
}
