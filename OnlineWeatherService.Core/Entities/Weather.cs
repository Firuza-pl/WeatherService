using OnlineWeatherService.SharedKernel.Core;

namespace OnlineWeatherService.Core.Entities
{
    public class Weather : Entity
    {
        public string? City { get; set; }
        public string? Description { get; set; }
        public decimal? Temperature { get; set; }
    }
}
