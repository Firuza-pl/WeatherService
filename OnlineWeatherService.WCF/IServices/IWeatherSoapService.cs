using OnlineWeatherService.WCF.Models.Request;
using OnlineWeatherService.WCF.Models.Response;
using System.ServiceModel;

namespace OnlineWeatherService.WCF.IServices
{
    [ServiceContract]
    public interface IWeatherSoapService
    {
        [OperationContract]
        Task<WeatherResponse> GetWeather(WeatherRequest request);

        [OperationContract]
        Task<ForeCastResponse> GetWeeklyForecast(ForeCastRequest request);
    }
}
