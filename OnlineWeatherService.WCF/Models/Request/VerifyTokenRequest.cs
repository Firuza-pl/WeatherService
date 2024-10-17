using System.Runtime.Serialization;

namespace OnlineWeatherService.WCF.Models.Request
{
	[DataContract]
	public class VerifyTokenRequest
	{
		[DataMember]
		public string? Token { get; set; }
		[DataMember]
		public string? PhoneNumber { get; set; }
	}
}
