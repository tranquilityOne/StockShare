using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Fengchao.Gallery.WebApi.Swagger
{
    /// <summary>
    /// Swagger filter for excluding properties from schema.
    /// </summary>
    public class SwaggerExcludeFilter : ISchemaFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var props2Exclude = context.Type
                .GetProperties()
                .Where(t => t.GetCustomAttributes(typeof(JsonIgnoreAttribute), false).Length > 0);

            foreach (var prop in props2Exclude)
            {
                if (schema.Properties.ContainsKey(prop.Name))
                {
                    schema.Properties.Remove(prop.Name);
                }
            }
        }
    }
}
