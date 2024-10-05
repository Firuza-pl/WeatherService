using OnlineWeatherService.Core.Entities;

namespace OnlineWeatherService.Application.DTO
{
    public class ForecastDTO
    {
        public string? City { get; set; }
        public List<Weather>? DailyForecasts { get; set; }
    }
}
