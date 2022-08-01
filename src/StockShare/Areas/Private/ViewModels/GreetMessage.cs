using System.ComponentModel.DataAnnotations;

namespace StockShare.Areas.Private.ViewModels
{
    /// <summary>
    /// Greet message.
    /// </summary>
    public class GreetMessage
    {
        /// <summary>
        /// Name of message receiver.
        /// </summary>
        [Required]
        public string ReceiverName { get; set; } = default!;

        /// <summary>
        /// Message content.
        /// </summary>
        [Required]
        public string Message { get; set; } = default!;
    }
}
