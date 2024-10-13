namespace OnlineWeatherService.Application.DTO
{
    public class UserDTO
    {
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public string? Email { get; set; }
		public DateTime? Birthday { get; set; }
		public byte? Status { get; set; }
		public byte? Gender { get; set; }
		public string? RefreshToken { get; set; }

	}
}
