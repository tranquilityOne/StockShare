using System.Text.RegularExpressions;

namespace StockShare.Core.Utils
{
    /// <summary>
    /// Provides methods for data validation.
    /// </summary>
    public static class ValidationUtil
    {
        /// <summary>
        /// Checks whether the given password is in valid format. Password must be consist of minimum 6 characters,
        /// at least three kinds of the following chars: { upper case words, lower case words, digits, special characters }.
        /// </summary>
        /// <param name="password">The password to check.</param>
        /// <returns>True if the given password in valid format; otherwise, false.</returns>
        public static bool IsValidPassword(string password)
        {
            const string AllowedSpecialChars = @"~!@#$%^&*()_+`\-=\[\]\\{}|;':"",\./<>?";
            var p1 = "(?=.*[A-Z])";
            var p2 = "(?=.*[a-z])";
            var p3 = @"(?=.*[\d])";
            var p4 = $@"(?=.*[{AllowedSpecialChars}])";
            var pattern = $@"^(?:{p1}{p2}{p3}{p4}|{p1}{p2}{p3}|{p1}{p2}{p4}|{p1}{p3}{p4}|{p2}{p3}{p4})(?:[\w{AllowedSpecialChars}]{{6,}})$";

            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            return Regex.IsMatch(password, pattern);
        }

        /// <summary>
        /// Checks whether the given email address is valid.
        /// </summary>
        /// <param name="email">The email address to check.</param>
        /// <returns>True if the given email address is valid; otherwise, false.</returns>
        public static bool IsValidEmail(string email)
        {
            // reference: https://stackoverflow.com/a/201378
            // test cases: [ "Abc123@email.co", "abc123@email.co.", "¨¢bc123@email.co" ]
            var pattern = @"^(?:[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-zA-Z0-9-]*[a-zA-Z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])$";

            return Regex.IsMatch(email, pattern);
        }
    }
}
