using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace OnlineWeatherService.SharedKernel.Logging
{
    public static class SerilogConfiguration
    {
        public static void ConfigureLogging(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSerilog();
            });
        }
    }
}
