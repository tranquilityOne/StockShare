using Newtonsoft.Json;
using System;

namespace Fengchao.Gallery.Core.Errors
{
    /// <summary>
    /// The same with <see cref="CodedException"/>.
    /// </summary>
    public class ErrorException : CodedException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorException"/> class with a specified error code.
        /// </summary>
        /// <param name="code">The code that describes the error.</param>
        public ErrorException(int code)
            : base(code)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorException"/> class with a specified error code and 
        /// message.
        /// </summary>
        /// <param name="code">The code that describes the error.</param>
        /// <param name="message">The message that describes the error.</param>
        public ErrorException(int code, string message)
            : base(code, message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorException"/> class with a specified error code and message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="code">Error code.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference if no inner exception 
        /// is specified.
        /// </param>
        [JsonConstructor]
        public ErrorException(int code, string message, Exception innerException)
            : base(code, message, innerException)
        {
        }
    }
}
