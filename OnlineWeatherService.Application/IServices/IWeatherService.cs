using OnlineWeatherService.Application.DTO;

namespace OnlineWeatherService.Application.IServices
{
    public interface IWeatherService
    {
        Task<WeatherDTO> GetWeatherAsync(string name);
        Task<ForecastDTO> GetWeeklyForecastAsync(string name);

    }
}
