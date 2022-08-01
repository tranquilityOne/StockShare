using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace StockShare.Data
{
    public class DesignTimeStockShareContextFactory : IDesignTimeDbContextFactory<StockShareContext>
    {
        public StockShareContext CreateDbContext(string[] args)
        {
            // Get environment
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            environment = string.IsNullOrWhiteSpace(environment) ? "Production" : environment;

            // Build config
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs"))
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddUserSecrets(Assembly.Load("StockShare"))
                .Build();

            var connectionString = config.GetConnectionString("StockShareContext");
            var dbOptions = new DbContextOptionsBuilder<StockShareContext>()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .Options;

            return new StockShareContext(dbOptions);
        }
    }
}
