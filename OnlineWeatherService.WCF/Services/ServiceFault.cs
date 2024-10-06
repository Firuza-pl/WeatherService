using System.Runtime.Serialization;

namespace OnlineWeatherService.WCF.Services
{
    [DataContract]
    public class ServiceFault
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public int ErrorCode { get; set; }

        public ServiceFault(string message, int errorCode)
        {
            Message = message;
            ErrorCode = errorCode;
        }
    }
}
