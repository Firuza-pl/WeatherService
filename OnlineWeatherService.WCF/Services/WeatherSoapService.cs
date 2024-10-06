using OnlineWeatherService.Application.IServices;
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
            _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
        }
        public async Task<WeatherResponse> GetWeather(string name)
        {
            try
            {

                if (string.IsNullOrEmpty(name))
                {
                    throw new FaultException<ServiceFault>(new ServiceFault("City name cannot be null or empty", 400));
                }

                var result = await _weatherService.GetWeatherAsync(name);
                
                if (result == null)
                {
                    throw new FaultException<ServiceFault>(new ServiceFault("City not found", 404));
                }

                var outputModel = new WeatherResponse()
                {
                    City = result.City,
                    Description = result.Description,
                    Temperature = result.Temperature
                };

                return outputModel;
            }
            catch (Exception ex)
            {
                //contain information about an error
                throw new FaultException<ServiceFault>(new ServiceFault(ex.Message, 500));

            }
        }


        public async Task<ForeCastResponse> GetWeeklyForecast(string name)
        {
            try
            {
                var reesult = await _weatherService.GetWeeklyForecastAsync(name);

                if (reesult is null) throw new FaultException<ServiceFault>(new ServiceFault("City not found", 404));

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
            catch (Exception ex)
            {
                throw new FaultException<ServiceFault>(new ServiceFault(ex.Message, 400));
            }
        }
    }
}
