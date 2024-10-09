using System.Runtime.Serialization;

namespace OnlineWeatherService.WCF.Models.Response
{
	[DataContract]
	public class UserResponse
	{
		[DataMember]
		public string? Name { get; set; }

		[DataMember]
		public string? Surname { get; set; }

		[DataMember]
		public byte? Gender { get; set; }

	}
}
