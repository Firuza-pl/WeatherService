using System.ComponentModel.DataAnnotations;

namespace OnlineWeatherService.Application.DTO
{
	public class LoginInputDTO
	{
		[Required]
		[Phone]
		public string? PhoneNumber { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string? Password { get; set; }
	}
}
