using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;
using StockShare.Core.Accessors;
using System;
using System.IO;

namespace StockShare.Tests
{
    /// <summary>
    /// The basic class of all tests.
    /// </summary>
    [TestClass]
    public class TestsBase
    {
        /// <summary>
        /// Gets instance of <see cref="TestContext"/>.
        /// </summary>
        public static TestContext Context { get; private set; } = default!;

        /// <summary>
        /// Gets instance of <see cref="IServiceProvider"/>.
        /// </summary>
        public static IServiceProvider ServiceProvider { get; private set; } = default!;

        /// <summary>
        /// The assembly initlization method.
        /// </summary>
        /// <param name="context"><see cref="TestContext"/>.</param>
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            Context = context;

            ServiceProvider = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webHostBuilder =>
                    webHostBuilder.ConfigureAppConfiguration((ctx, builder) =>
                    {
                        ctx.HostingEnvironment.EnvironmentName = "Development";

                        builder.SetBasePath(Path.Combine(AppContext.BaseDirectory, "Configs"))
                            .AddJsonFile("appsettings.json", optional: false)
                            .AddJsonFile($"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json", optional: true)
                            .AddEnvironmentVariables()
                            .AddUserSecrets<Program>();
                    })
                    .ConfigureLogging((ctx, builder) =>
                    {
                        builder.ClearProviders();
                    })
                    .UseStartup<Startup>())
                .UseSerilog()
                .Build()
                .Services;

            ServiceProviderAccessor.ServiceProvider = ServiceProvider;
        }
    }
}
