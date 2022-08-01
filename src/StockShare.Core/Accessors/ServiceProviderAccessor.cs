using System;

namespace StockShare.Core.Accessors
{
    /// <summary>
    /// Provides <see langword="static"/> access to <see cref="IServiceProvider"/>.
    /// </summary>
    public static class ServiceProviderAccessor
    {
        /// <summary>
        /// A <see cref="IServiceProvider"/> instance.
        /// </summary>
        public static IServiceProvider ServiceProvider { get; set; } = default!;
    }
}
