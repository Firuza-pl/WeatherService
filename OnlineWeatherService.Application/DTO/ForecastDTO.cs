using OnlineWeatherService.Core.Entities;

namespace OnlineWeatherService.Application.DTO
{
    public class ForecastDTO
    {
        public string? City { get; set; }
        public List<WeatherDTO>? DailyForecasts { get; set; }
    }
}
