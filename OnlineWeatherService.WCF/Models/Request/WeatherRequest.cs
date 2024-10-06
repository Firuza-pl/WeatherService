using System.Runtime.Serialization;

namespace OnlineWeatherService.WCF.Models.Request
{
    [DataContract]
    public class WeatherRequest
    {
        [DataMember]
        public string? City { get; set; }
    }
}
