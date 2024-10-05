using OnlineWeatherService.WCF.Models.Response;
using OnlineWeatherService.WCF.Services;
using System.ServiceModel;

namespace OnlineWeatherService.WCF.IServices
{
    [ServiceContract]
    public interface IWeatherSoapService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceFault))] //will return ServiceFault type
        Task<WeatherResponse> GetWeather(string name);

        [OperationContract]
        [FaultContract(typeof(ServiceFault))] 
        Task<ForeCastResponse> GetWeeklyForecast(string name);
    }
}
