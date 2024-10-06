using System.Runtime.Serialization;

namespace OnlineWeatherService.WCF.Models.Response
{
    [DataContract]
    public class WeatherResponse
    {
        [DataMember]
        public string? City { get; set; }

        [DataMember]
        public string? Description { get; set; }

        [DataMember]
        public decimal? Temperature { get; set; }
    }
}
