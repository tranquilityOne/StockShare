using Fengchao.Gallery.Core.Boolean;
using Fengchao.Gallery.Core.Errors;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockShare.Areas.Authentication.ViewModels
{
    /// <summary>
    /// Request for user login.
    /// </summary>
    public class LoginRequest : PasswordValidationRequest
    {
        /// <summary>
        /// Username.
        /// </summary>
        [Required]
        public string Username { get; set; } = default!;
    }
}
