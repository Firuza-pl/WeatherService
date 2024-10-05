using OnlineWeatherService.SharedKernel.Core;

namespace OnlineWeatherService.Core.Entities
{
    public class Forecast : Entity
    {
        public string? City { get; private set; }
        public List<Weather>? DailyForecasts { get; private set; }
    }
}
