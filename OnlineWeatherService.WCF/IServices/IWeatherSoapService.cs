using OnlineWeatherService.WCF.Models.Response;
using System.ServiceModel;

namespace OnlineWeatherService.WCF.IServices
{
    [ServiceContract]
    public interface IWeatherSoapService
    {
        [OperationContract]
        WeatherResponse GetWeather(string city);

        [OperationContract]
        ForeCastResponse GetWeeklyForecast(string city);
    }
}
