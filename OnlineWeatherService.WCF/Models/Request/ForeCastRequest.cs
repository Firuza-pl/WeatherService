using System.Runtime.Serialization;

namespace OnlineWeatherService.WCF.Models.Request
{
    [DataContract]
    public class ForeCastRequest
    {
        [DataMember]
        public string? City { get; set; }
    }
}
