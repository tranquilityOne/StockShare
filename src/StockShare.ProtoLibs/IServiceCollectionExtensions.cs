using Fengchao.Greeter;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace StockShare.ProtoLibs
{
    /// <summary>
    /// Extension methods for adding grpc services to an <see cref="IServiceCollection"/>.
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds grpc clients to application's request pipeline.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="conf"></param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddGrpcServices(this IServiceCollection services, IConfiguration conf)
        {
            // Additional configuration is required to call insecure gRPC services with the .NET Core client.
            // This switch must be set before creating the GrpcChannel/HttpClient.
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            return services
                .AddGrpcClient<GreeterService.GreeterServiceClient>(conf.GetSection("GrpcServices:Greeter").Value);
        }

        private static IServiceCollection AddGrpcClient<TClient>(this IServiceCollection services, string serviceAddress)
            where TClient : ClientBase
        {
            services.AddGrpcClient<TClient>((provider, options) =>
            {
                options.Address = serviceAddress.StartsWith("http")
                    ? new Uri(serviceAddress)
                    : new Uri($"http://{serviceAddress}");

                options.ChannelOptionsActions.Add(channelOptions =>
                {
                    // handles grpc log by custom middleware.
                    channelOptions.LoggerFactory = new LoggerFactory();
                    channelOptions.MaxReceiveMessageSize = 8 * 1024 * 1024;
                });
            });

            return services;
        }
    }
}
