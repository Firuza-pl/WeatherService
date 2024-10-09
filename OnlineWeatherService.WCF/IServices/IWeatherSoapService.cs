using OnlineWeatherService.WCF.Models.Response;
using System.ServiceModel;

namespace OnlineWeatherService.WCF.IServices
{
    [ServiceContract]
    public interface IWeatherSoapService
    {
        [OperationContract]
        Task<WeatherResponse> GetWeather(string cityName);

        [OperationContract]
        Task<ForeCastResponse> GetWeeklyForecast(string name);
    }
}
