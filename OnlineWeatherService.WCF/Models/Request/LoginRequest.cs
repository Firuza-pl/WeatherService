using System.Runtime.Serialization;

namespace OnlineWeatherService.WCF.Models.Request
{
    [DataContract]
    public class LoginRequest
    {
        [DataMember]
        public string? PhoneNumber { get; set; }

        [DataMember]
        public string? Password { get; set; }
    }
}
