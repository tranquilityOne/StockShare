namespace StockShare.Areas.Authentication.ViewModels
{
    /// <summary>
    /// Token.
    /// </summary>
    public class TokenInfo
    {
        /// <summary>
        /// Token value.
        /// </summary>
        public string? AccessToken { get; set; }

        /// <summary>
        /// Refresh token.
        /// </summary>
        public string? RefreshToken { get; set; }

        /// <summary>
        /// Type type.
        /// </summary>
        public string TokenType { get; set; } = "bearer";

        /// <summary>
        /// Expires in.
        /// </summary>
        public long ExpiresIn { get; set; }

        /// <summary>
        /// Login name.
        /// </summary>
        public string? LoginName { get; set; }

        /// <summary>
        /// Staff name.
        /// </summary>
        public string? StaffName { get; set; }
    }
}
