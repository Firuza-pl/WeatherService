using OnlineWeatherService.Core.Entities;

namespace OnlineWeatherService.WCF.Models.Response
{
    public class ForeCastResponse
    {
        public string? City { get; set; }
        public List<WeatherResponse>? DailyForecasts { get; set; }
    }
}
