using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Fengchao.Gallery.WebApi.Swagger
{
    /// <summary>
    /// Swagger filter for excluding properties from schema.
    /// </summary>
    public class SwaggerHeaderFilter : IOperationFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();
            var attrs = context.MethodInfo.GetCustomAttributes<HttpHeaderAttribute>();

            foreach (var attr in attrs)
            {
                var existingParam = operation.Parameters.FirstOrDefault(p =>
                    p.In == ParameterLocation.Header && p.Name == attr.Name);

                // removes description from [FromHeader] argument attribute.
                if (existingParam != null)
                {
                    operation.Parameters.Remove(existingParam);
                }

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = attr.Name,
                    In = ParameterLocation.Header,
                    Description = attr.Description,
                    Required = attr.IsRequired,
                    Schema = string.IsNullOrEmpty(attr.DefaultValue)
                        ? null
                        : new OpenApiSchema
                        {
                            Type = "String",
                            Default = new OpenApiString(attr.DefaultValue)
                        }
                });
            }
        }
    }
}
