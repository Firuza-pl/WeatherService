using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineWeatherService.Application.Helper
{
	public class TokenConfiguration
	{
		public static string CreateToken(AppSettings appSettings, string id, string name)
		{
			try
			{
				var key = Encoding.ASCII.GetBytes(appSettings.Secret);

				//creating jwt
				var tokenHandler = new JwtSecurityTokenHandler();

				var claims = new ClaimsIdentity([

					new Claim(ClaimTypes.Name,id),
					new Claim(ClaimTypes.Role,name)
				]);

				var description = new SecurityTokenDescriptor
				{
					//payload
					Subject = claims,
					Expires = DateTime.UtcNow.AddDays(1),

					//header
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

				};

				var token = tokenHandler.CreateToken(description);
				var tokenString = tokenHandler.WriteToken(token);

				return tokenString;
			}
			catch
			{

				throw;
			}
		}

	}
}
