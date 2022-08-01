using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;

namespace Fengchao.Gallery.WebApi.Utils
{
    /// <summary>
    /// Route matcher.
    /// </summary>
    public static class RouteMatcher
    {
        /// <summary>
        /// Matches route template and request path.
        /// </summary>
        /// <param name="routeTemplate">Route template.</param>
        /// <param name="requestPath">Request path.</param>
        /// <returns>
        /// An object of <see cref="RouteValueDictionary"/> if matched successfully; otherwise, null.
        /// </returns>
        public static RouteValueDictionary? Match(string routeTemplate, string requestPath)
        {
            var template = TemplateParser.Parse(routeTemplate);
            var matcher = new TemplateMatcher(template, GetDefaults(template));
            var values = new RouteValueDictionary();
            var matched = matcher.TryMatch(requestPath, values);

            return matched ? values : null;
        }

        private static RouteValueDictionary GetDefaults(RouteTemplate parsedTemplate)
        {
            var result = new RouteValueDictionary();

            foreach (var parameter in parsedTemplate.Parameters)
            {
                if (parameter != null && parameter.Name != null && parameter.DefaultValue != null)
                {
                    result.Add(parameter!.Name, parameter!.DefaultValue);
                }
            }

            return result;
        }
    }
}
