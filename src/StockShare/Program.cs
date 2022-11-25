using Fengchao.Gallery.Logging;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using StockShare.Core.Accessors;
using StockShare.Data;
using StockShare.HostedServices;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Winton.Extensions.Configuration.Consul;

[assembly: InternalsVisibleTo("StockShare.Tests")]
namespace StockShare
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
#if DEBUG
            LoggerInitializer.InitSerilogger(Path.Combine(AppContext.BaseDirectory, "Configs"), "appsettings.log.json");
#else
            LoggerInitializer.InitSerilogger();
#endif

            try
            {
                var host = CreateWebHostBuilder(args).Build();
                ServiceProviderAccessor.ServiceProvider = host.Services;
                await host.RunAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"{Assembly.GetEntryAssembly()!.GetName().Name} terminated unexpectedly.");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).
                ConfigureWebHostDefaults(webHostBuilder =>
                    webHostBuilder.ConfigureAppConfiguration((ctx, builder) =>
                    {
                        builder.SetBasePath(Path.Combine(AppContext.BaseDirectory, "Configs"))
                            .AddJsonFile("appsettings.json", optional: false)
                            .AddJsonFile($"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json", optional: true)
                            .AddJsonFile($"appsettings.ratelimit.json", optional: false)
                            .AddConsul("app/stockshare", options =>
                            {
                                options.ConsulConfigurationOptions = cco => { cco.Address = new Uri("http://consul:8500"); };
                                options.Optional = true;
                                options.ReloadOnChange = true;
                                options.OnLoadException = exceptionContext => { exceptionContext.Ignore = true; };
                            })
                            .AddEnvironmentVariables()
                            .AddCommandLine(args);

                        if (ctx.HostingEnvironment.IsDevelopment())
                        {
                            builder.AddUserSecrets<Program>();
                        }
                    })
                    .ConfigureLogging((ctx, builder) =>
                    {
                        builder.ClearProviders();
                    })
                    .ConfigureServices(services =>
                    {
                        services.AddHostedService<DefaultHostedService>();
                    })
                    .UseStartup<Startup>())
                .UseSerilog();
    }
}
