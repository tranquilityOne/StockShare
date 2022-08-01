namespace Fengchao.Gallery.WebApi.ViewModels
{
    /// <summary>
    /// Http response result with status code.
    /// </summary>
    public class StatusResponseResult
    {
        /// <summary>
        /// Gets or sets response result status code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets response result message.
        /// </summary>
        public string? Message { get; set; }
    }
}
