namespace Fengchao.Gallery.WebApi.ViewModels
{
    /// <summary>
    /// Http response result with status code and response data.
    /// </summary>
    /// <typeparam name="TData">The type of response data.</typeparam>
    public class StructureResponseResult<TData> : StatusResponseResult
        where TData : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseResult{T}"/> class.
        /// </summary>
        public StructureResponseResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseResult{T}"/> class.
        /// </summary>
        /// <param name="data">Response data.</param>
        public StructureResponseResult(TData data)
        {
            Data = data;
        }

        /// <summary>
        /// Gets or sets response data.
        /// </summary>
        public TData Data { get; set; }
    }
}
