namespace Fengchao.Gallery.WebApi.ViewModels
{
    /// <summary>
    /// Http response result with status code and string response data.
    /// </summary>
    public class StringResponseResult : ResponseResult<string?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringResponseResult"/> class.
        /// </summary>
        public StringResponseResult()
            : base(default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringResponseResult"/> class.
        /// </summary>
        /// <param name="data">Response data.</param>
        public StringResponseResult(string? data)
            : base(data)
        {
        }
    }
}
