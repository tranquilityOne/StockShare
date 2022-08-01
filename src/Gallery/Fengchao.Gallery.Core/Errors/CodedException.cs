using Newtonsoft.Json;
using System;

namespace Fengchao.Gallery.Core.Errors
{
    /// <summary>
    /// Represents errors with error code that occur during application execution.
    /// </summary>
    public class CodedException : Exception
    {
        /// <summary>
        /// Gets error code.
        /// </summary>
        public virtual int Code { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodedException"/> class with a specified error code.
        /// </summary>
        /// <param name="code">The code that describes the error.</param>
        public CodedException(int code)
        {
            Code = code;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodedException"/> class with a specified error code and 
        /// message.
        /// </summary>
        /// <param name="code">The code that describes the error.</param>
        /// <param name="message">The message that describes the error.</param>
        public CodedException(int code, string message)
            : base(message)
        {
            Code = code;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodedException"/> class with a specified error code and message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="code">Error code.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference if no inner exception 
        /// is specified.
        /// </param>
        [JsonConstructor]
        public CodedException(int code, string message, Exception innerException)
            : base(message, innerException)
        {
            Code = code;
        }
    }
}
