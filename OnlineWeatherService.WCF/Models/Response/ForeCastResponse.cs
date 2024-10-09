using System.Runtime.Serialization;

namespace OnlineWeatherService.WCF.Models.Response
{
    [DataContract]
    public class ForeCastResponse
    {
        [DataMember]
        public string? City { get; set; }

        [DataMember]
        public List<DailyResponse>? DailyForecast { get; set; }
    }
}
