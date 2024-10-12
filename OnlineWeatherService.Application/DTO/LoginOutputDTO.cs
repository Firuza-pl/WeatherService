﻿namespace OnlineWeatherService.Application.DTO
{
	public class LoginOutputDTO
	{
		public string? Id { get; set; }

		public string? Name { get; set; }

		public string? Surname { get; set; }

		public string? Email { get; set; }

		public string? PhoneNumber { get; set; }

		public string? Password { get; set; }

		public string? Gender { get; set; }

		public string? AccessToken { get; set; }

		public string? RefreshToken { get; set; }
	}
}
