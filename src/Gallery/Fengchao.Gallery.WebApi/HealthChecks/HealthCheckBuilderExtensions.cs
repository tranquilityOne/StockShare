using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;

namespace Fengchao.Gallery.WebApi.HealthChecks
{
    /// <summary>
    /// Provides extensions for <see cref="IHealthChecksBuilder"/>.
    /// </summary>
    public static class HealthCheckBuilderExtensions
    {
        /// <summary>
        /// Adds healthcheck for memory.
        /// </summary>
        /// <param name="builder">The <see cref="IHealthChecksBuilder"/>.</param>
        /// <param name="maximumMemoryBytes">Threshold of memory limit in bytes. 1GB as default.</param>
        /// <param name="name">
        /// The name of the health check. If the provided value is null, then 'memory' will be as default.
        /// </param>
        /// <param name="failureStatus">
        /// The <see cref="HealthStatus"/> that should be reported when the health check reports a failure.
        /// If the provided value is null, then <see cref="HealthStatus.Degraded"/> will be reported.
        /// </param>
        /// <param name="tags">A list of tags that can be used to filter health checks.</param>
        /// <param name="timeout">An optional <see cref="TimeSpan"/> representing the timeout of the check.</param>
        /// <returns>The <see cref="IHealthChecksBuilder"/> so that additional calls can be chained.</returns>
        public static IHealthChecksBuilder AddMemoryHealthCheck(
            this IHealthChecksBuilder builder,
            long maximumMemoryBytes = 1024L * 1024L * 1024L,
            string? name = null,
            HealthStatus? failureStatus = null,
            IEnumerable<string>? tags = null,
            TimeSpan? timeout = null)
        {
            // Register a check of type GCInfo.
            builder.AddCheck(
                name ?? "memory",
                new MemoryHealthCheck(maximumMemoryBytes),
                failureStatus ?? HealthStatus.Degraded,
                tags,
                timeout);

            return builder;
        }
    }
}
