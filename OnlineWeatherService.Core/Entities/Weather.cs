using OnlineWeatherService.SharedKernel.Core;

namespace OnlineWeatherService.Core.Entities
{
    public class Weather : Entity
    {
        public string? City { get; private set; }
        public string? Description { get; private set; }
        public decimal? Temperature { get; private set; }
    }
}
