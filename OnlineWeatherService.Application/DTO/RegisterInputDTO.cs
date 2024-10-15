namespace OnlineWeatherService.Application.DTO
{
	public class RegisterInputDTO
	{
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Password { get; set; }
		public string? Email { get; set; }
		public DateTime? Birthday { get; set; }
		public byte? Status { get; set; }
		public byte? Gender { get; set; }
	}
}
