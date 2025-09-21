

using Microsoft.Extensions.Hosting;

namespace MovieDirectorApp.Infrastructure.Logging
{
    public static class LoggingExtension
    {
        public static void AddSerilogLogging(this IHostBuilder hostBuilder)
        {
            //hostBuilder.UseSerilog((context, config) =>
            //{
            //    config
            //        .MinimumLevel.Information()
            //        .Enrich.FromLogContext()
            //        .WriteTo.Console()
            //        .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day);
            //});
        }
    }
}
