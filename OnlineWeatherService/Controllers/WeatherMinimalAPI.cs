using Microsoft.AspNetCore.Mvc;
using OnlineWeatherService.WCF.Models.Request;
using OnlineWeatherService.WCF.Services;

namespace OnlineWeatherService.Controllers
{
    public static class WeatherMinimalAPI
    {
        public static void WeatherEndPoint(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapGet("", async ([FromBody] WeatherRequest command, [FromServices] WeatherSoapService client) =>
            {
                try
                {
                    var result = client.GetWeather(command);
                }
                catch (Exception)
                {
                    throw;
                }
            })
                .WithName("GetWeather");

        }
    }
}
