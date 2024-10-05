using OnlineWeatherService.Application.IServices;
using OnlineWeatherService.Core.Entities;
using OnlineWeatherService.WCF.IServices;
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
        public WeatherResponse GetWeather(string city)
        {
            var result = _weatherService.GetWeatherAsync(city).Result;
            if (result is null) throw new FaultException("Forecast data not found.");

            var outputModel = new WeatherResponse()
            {
                City = result.City,
                Description = result.Description,
                Temperature = result.Temperature    
            };

            return outputModel;
        }

        public ForeCastResponse GetWeeklyForecast(string city)
        {
            var reesult = _weatherService.GetWeeklyForecastAsync(city).Result;
            if (reesult is null) throw new FaultException("Forecast data not found.");

            var outputModel = new ForeCastResponse()
            {
                City = reesult.City,
                DailyForecasts = reesult.DailyForecasts.Select(p => new WeatherResponse()
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
