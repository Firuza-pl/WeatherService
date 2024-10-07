using System.Runtime.Serialization;

namespace OnlineWeatherService.WCF.Models.Response
{
    [DataContract]
    public class DailyResponse
    {
        [DataMember]
        public string? Description { get; set; }

        [DataMember]
        public decimal? Temperature { get; set; }
    }
}
