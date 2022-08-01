using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fengchao.Gallery.Core.Linq
{
    /// <summary>
    /// Specifies the expected order of response data.
    /// </summary>
    public class OrderBy : IValidatableObject
    {
        private static readonly string[] _forbiddenFieldChars = new[] { ";", "'", "--", @"/\*", @"\*/", "xp_" };
        private static readonly string _validateFieldPattern =
            string.Join("|", _forbiddenFieldChars.Select(s => $"(?=.*{s})"));

        /// <summary>
        /// The key of the sort.
        /// </summary>
        [Required]
        public string Field { get; set; } = string.Empty;

        /// <summary>
        /// If true, the response data will be sorted in ascending; otherwise, in descending order.
        /// The default value is true.
        /// </summary>
        [JsonIgnore]
        public bool InAsc
        {
            get
            {
                return Type == 0;
            }
        }

        /// <summary>
        /// The type of sort, 0 for asc, 1 for desc.
        /// </summary>
        public int Type { get; set; }

        /// <inheritdoc/>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var trimmedKey = Field.Trim();

            if (string.IsNullOrEmpty(trimmedKey)
                || trimmedKey.Any(char.IsWhiteSpace)
                || Regex.IsMatch(trimmedKey, _validateFieldPattern))
            {
                throw new ArgumentException(nameof(Field));
            }

            if (Type != 0 && Type != 1)
            {
                throw new ArgumentException(nameof(Type));
            }

            return Array.Empty<ValidationResult>();
        }
    }
}
