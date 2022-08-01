namespace StockShare.Core.Configuration
{
    /// <summary>
    /// JWT bearer options.
    /// </summary>
    public class JwtIssuerOptions
    {
        /// <summary>
        /// Gets or sets issuer.
        /// </summary>
        public string Issuer { get; set; } = default!;

        /// <summary>
        /// Gets or sets audience.
        /// </summary>
        public string Audience { get; set; } = default!;

        /// <summary>
        /// Gets or sets secret.
        /// </summary>
        public string Secret { get; set; } = default!;

        /// <summary>
        /// Token expiration in minutes.
        /// </summary>
        public int TokenExpirationInMinutes { get; set; } = 120;

        /// <summary>
        /// Token expiration in minutes.
        /// </summary>
        public int RefreshTokenExpirationInMinutes { get; set; } = 10080;

        /// <summary>
        /// Instance name.
        /// </summary>
        public string InstanceName { get; set; } = default!;
    }
}
