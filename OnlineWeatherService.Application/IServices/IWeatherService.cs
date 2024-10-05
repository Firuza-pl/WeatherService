using OnlineWeatherService.Application.DTO;

namespace OnlineWeatherService.Application.IServices
{
    public interface IWeatherService
    {
        Task<WeatherDTO> GetWeatherAsync(CreateWeatherDTO request);
        Task<ForecastDTO> GetWeeklyForecastAsync(CreateForecastDTO request);

    }
}
