using System.ComponentModel.DataAnnotations;

namespace StockShare.Areas.Authentication.ViewModels
{
    /// <summary>
    /// Request for validating user password.
    /// </summary>
    public class PasswordValidationRequest
    {
        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        public string Password { get; set; } = default!;
    }
}
