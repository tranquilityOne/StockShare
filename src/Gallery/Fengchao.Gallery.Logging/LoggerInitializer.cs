using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.Graylog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Fengchao.Gallery.Logging
{
    /// <summary>
    /// Serilog logger initializer.
    /// </summary>
    public static class LoggerInitializer
    {
        private static readonly string _environmentName
            = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

        /// <summary>
        /// Initializes serilog logger with default configurations.
        /// </summary>
        public static void InitSerilogger()
        {
            const string ConfigFilePath = "Fengchao.Gallery.Logging.appsettings.log.json";

            var defaultConfigSource = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(ConfigFilePath);

            var configuration = new ConfigurationBuilder()
                .AddJsonStream(defaultConfigSource)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.WithProperty("Environment", _environmentName)
                .CreateLogger();
        }

        /// <summary>
        /// Initializes serilog logger with custom configurations in JSON format.
        /// </summary>
        /// <param name="jsonConfig">Json formatted configuration content of serilog.</param>
        public static void InitSerilogger(string jsonConfig)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(jsonConfig)))
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.WithProperty("Environment", _environmentName)
                .CreateLogger();
        }

        /// <summary>
        /// Initializes serilog logger with custom configurations in JSON file.
        /// </summary>
        /// <param name="basePath">The absolute path of file-based providers.</param>
        /// <param name="filePath">
        /// Path of serilog configurations relative to the base path stored in 
        /// <see cref="IConfigurationBuilder.Properties"/> of builder.
        /// </param>
        public static void InitSerilogger(string basePath, string filePath)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(filePath)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.WithProperty("Environment", _environmentName)
                .CreateLogger();
        }
    }
}
