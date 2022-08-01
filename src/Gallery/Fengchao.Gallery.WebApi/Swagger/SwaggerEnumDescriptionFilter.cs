using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Fengchao.Gallery.WebApi.Swagger
{
    /// <summary>
    /// Swagger filter for displaying enum values with string description.
    /// </summary>
    public class SwaggerEnumDescriptionFilter : IDocumentFilter
    {
        private static readonly IEnumerable<Type>? _allEnumTypes = Assembly.GetEntryAssembly()?
            .GetReferencedAssemblies()
            .Select(Assembly.Load)
            .Concat(new[] { Assembly.GetEntryAssembly() })
            .Where(x => x != null)
            .SelectMany(x => x!.GetTypes())
            .Where(x => x.IsEnum);

        /// <inheritdoc />
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            UpdateEnumDescriptionsInSchemas(swaggerDoc);
            UpdateEnumDescriptionsInParameters(swaggerDoc);
        }

        private void UpdateEnumDescriptionsInSchemas(OpenApiDocument swaggerDoc)
        {
            var enumSchemas = swaggerDoc.Components.Schemas
                .Where(x => x.Value?.Enum?.Count > 0);

            foreach (var schema in enumSchemas)
            {
                schema.Value.Description = BuildEnumSchemaDescription(schema);
            }
        }

        private void UpdateEnumDescriptionsInParameters(OpenApiDocument swaggerDoc)
        {
            foreach (var pathItem in swaggerDoc.Paths.Values)
            {
                if (pathItem.Operations == null)
                {
                    continue;
                }

                foreach (var operation in pathItem.Operations)
                {
                    foreach (var param in operation.Value.Parameters)
                    {
                        var paramSchema = swaggerDoc.Components.Schemas
                            .FirstOrDefault(x => x.Key == param.Schema?.Reference?.Id);

                        if (!string.IsNullOrEmpty(paramSchema.Key))
                        {
                            param.Description = paramSchema.Value.Description;
                        }
                    }
                }
            }
        }

        private string BuildEnumSchemaDescription(KeyValuePair<string, OpenApiSchema> schema)
        {
            const string LineBreaker = "<br />";
            var propertyEnums = schema.Value.Enum;

            if (propertyEnums == null || propertyEnums.Count == 0)
            {
                return schema.Value.Description;
            }

            var enumType = GetEnumTypeBySchema(schema);

            if (enumType == null)
            {
                return schema.Value.Description;
            }

            var enumDescriptions = new List<string?>() { schema.Value.Description };

            foreach (OpenApiInteger enumOption in propertyEnums)
            {
                int enumInt = enumOption.Value;

                enumDescriptions.Add(string.Format("{0} = {1}", enumInt, Enum.GetName(enumType, enumInt)));
            }

            return string.Join(LineBreaker, enumDescriptions.Where(d => !string.IsNullOrWhiteSpace(d)).ToArray());
        }

        private Type? GetEnumTypeBySchema(KeyValuePair<string, OpenApiSchema> schema)
        {
            var types = _allEnumTypes?
                .Where(x => x.FullName == schema.Key || x.Name == schema.Key)
                .Where(x => x.GetEnumValues().Length == schema.Value.Enum.Count);

            return types?.FirstOrDefault();
        }
    }
}
