using Fengchao.Gallery.WebApi.Middlewares;
using System;

namespace Fengchao.Gallery.WebApi.Attributes
{
    /// <summary>
    /// Identifies an action that bypasses the track of <see cref="AccessLogMiddleware"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class BypassAccessLoggerAttribute : Attribute
    {

    }
}
