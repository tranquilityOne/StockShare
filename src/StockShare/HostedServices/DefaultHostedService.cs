using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace StockShare.HostedServices
{
    /// <summary>
    /// The default implement of <see cref="IHostedService"/>.
    /// </summary>
    public class DefaultHostedService : IHostedService
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultHostedService"/> class.
        /// </summary>
        /// <param name="logger"></param>
        public DefaultHostedService(
            ILogger<DefaultHostedService> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting default hosted service.");

            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
