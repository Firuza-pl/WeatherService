using System.Runtime.Serialization;

namespace OnlineWeatherService.WCF.Services
{
    [DataContract]
    public class ServiceFault
    {
        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public int ErrorCode { get; set; }

        public ServiceFault(string message, int errorCode)
        {
            ErrorMessage = message;
            ErrorCode = errorCode;
        }
    }
}
