using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Fengchao.Gallery.WebApi.HealthChecks
{
    /// <summary>
    /// Represents a health check, which can be used to check the status of allocated memory.
    /// </summary>
    public class MemoryHealthCheck : IHealthCheck
    {
        private const long DEFAULTTHRESHOLD = 1024L * 1024L * 1024L;
        private readonly long _threshold;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryHealthCheck"/> class.
        /// </summary>
        public MemoryHealthCheck()
        {
            _threshold = DEFAULTTHRESHOLD;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryHealthCheck"/> class.
        /// </summary>
        /// <param name="maximumMemoryBytes">Threshold of memory limit in bytes.</param>
        public MemoryHealthCheck(long maximumMemoryBytes)
        {
            _threshold = maximumMemoryBytes;
        }

        /// <inheritdoc/>
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            // Include GC information in the reported diagnostics.
            var allocated = GC.GetTotalMemory(forceFullCollection: false);
            var data = new Dictionary<string, object>()
            {
                { "AllocatedBytes", allocated },
                { "Gen0Collections", GC.CollectionCount(0) },
                { "Gen1Collections", GC.CollectionCount(1) },
                { "Gen2Collections", GC.CollectionCount(2) },
            };

            var status = (allocated < _threshold)
                ? HealthStatus.Healthy
                : HealthStatus.Unhealthy;

            return Task.FromResult(new HealthCheckResult(
                status,
                description: $"Reports degraded status if allocated bytes >= {_threshold} bytes.",
                exception: null,
                data: data));
        }
    }
}
