using System;

namespace Fengchao.Gallery.WebApi.Swagger
{
    /// <summary>
    /// Specifies the method that this attribute is applied to receives custom header.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class HttpHeaderAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpHeaderAttribute"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="defaultValue"></param>
        /// <param name="isRequired"></param>
        public HttpHeaderAttribute(string name, string description = "", string defaultValue = "", bool isRequired = false)
        {
            Name = name;
            Description = description;
            DefaultValue = defaultValue;
            IsRequired = isRequired;
        }

        /// <summary>
        /// Header name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Header description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Default value of header.
        /// </summary>
        public string DefaultValue { get; }

        /// <summary>
        /// Whether this header is required.
        /// </summary>
        public bool IsRequired { get; }
    }
}
