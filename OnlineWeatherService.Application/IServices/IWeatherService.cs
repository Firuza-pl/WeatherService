using OnlineWeatherService.Application.DTO;

namespace OnlineWeatherService.Application.IServices
{
    public interface IWeatherService
    {
       Task<WeatherDTO> GetWeatherAsync(string cityName);
        Task<ForecastDTO> GetWeeklyForecastAsync(string cityName);

    }
}
