using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace StockShare.Areas.Authentication.ViewModels
{
    /// <summary>
    /// Request for refreshing token.
    /// </summary>
    public class RefreshTokenRequest
    {
        /// <summary>
        /// Access token.
        /// </summary>
        [Required]
        public string AccessToken { get; set; } = default!;

        /// <summary>
        /// Refresh token.
        /// </summary>
        [Required]
        public string RefreshToken { get; set; } = default!;
    }
}
