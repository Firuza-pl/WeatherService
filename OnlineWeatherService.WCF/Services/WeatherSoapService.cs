using OnlineWeatherService.Application.DTO;
using OnlineWeatherService.Application.IServices;
using OnlineWeatherService.WCF.IServices;
using OnlineWeatherService.WCF.Models.Request;
using OnlineWeatherService.WCF.Models.Response;
using System.ServiceModel;

namespace OnlineWeatherService.WCF.Services
{
    public class WeatherSoapService : IWeatherSoapService
    {
        private readonly IWeatherService _weatherService;
        public WeatherSoapService(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        public async Task<WeatherResponse> GetWeather(WeatherRequest request)
        {
            var result = await _weatherService.GetWeatherAsync(
                new CreateWeatherDTO
                {
                    City = request.City
                });

            if (result is null) throw new FaultException("Forecast data not found.");

            var outputModel = new WeatherResponse()
            {
                City = result.City,
                Description = result.Description,
                Temperature = result.Temperature
            };

            return outputModel;
        }


        public async Task<ForeCastResponse> GetWeeklyForecast(ForeCastRequest request)
        {
            var reesult = await _weatherService.GetWeeklyForecastAsync(
                new CreateForecastDTO
                {
                    City = request.City
                });

            if (reesult is null) throw new FaultException("Forecast data not found.");

            var outputModel = new ForeCastResponse
            {
                City = reesult.City,
                DailyForecasts = reesult.DailyForecasts.Select(p => new WeatherResponse
                {
                    City = p.City,
                    Description = p.Description,
                    Temperature = p.Temperature
                }).ToList()
            };

            return outputModel;
        }
    }
}
