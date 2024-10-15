using System.Runtime.Serialization;

namespace OnlineWeatherService.WCF.Models.Request
{
	[DataContract]
	public class RegisterRequest
	{
		[DataMember]
		public string? Name { get; set; }

		[DataMember]
		public string? Surname { get; set; }

		[DataMember]
		public string? PhoneNumber { get; set; }

		[DataMember]
		public string? Password { get; set; }

		[DataMember]
		public string? Email { get; set; }

		[DataMember]
		public DateTime? Birthday { get; set; }

		[DataMember]
		public byte? Status { get; set; }

		[DataMember]
		public byte? Gender { get; set; }
	}
}
