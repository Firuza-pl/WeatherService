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
				var key = Encoding.ASCII.GetBytes(appSettings.Secret); //convert secret key into byte array

				var tokenHandler = new JwtSecurityTokenHandler();

				var claims = new ClaimsIdentity([
					new Claim(ClaimTypes.Name, id),
				new Claim(ClaimTypes.Role,name)
					]);

				var descriptor = new SecurityTokenDescriptor
				{
					//payload
					Subject = claims,
					Expires = DateTime.UtcNow.AddHours(1),
					//header
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
				};

				var token = tokenHandler.CreateToken(descriptor);
				var tokenString = tokenHandler.WriteToken(token);
				return tokenString;
			}
			catch
			{

				throw;
			}
		}

		public static ClaimsPrincipal GetPrincipal(AppSettings appSettings, string token)
		{
			try
			{
				var key = Encoding.ASCII.GetBytes(appSettings.Secret);

				var tokenHandler = new JwtSecurityTokenHandler();

				var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token);

				if (securityToken is null)
					throw new ArgumentNullException(nameof(securityToken));

				var parameters = new TokenValidationParameters
				{
					ValidateIssuer = false, //change for security
					ValidateAudience = false,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuerSigningKey = true,
					RequireExpirationTime = true,
					ClockSkew = TimeSpan.FromMinutes(5),
				};

				SecurityToken security;
				ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(token, parameters, out security);
				JwtSecurityToken jwtSecurity = security as JwtSecurityToken;  //for furture options if needed

				return claimsPrincipal;
			}
			catch 
			{

				throw;
			}

		}

		public static string ValidateToken(AppSettings appSettings, string token)
		{
			try
			{
				string? username = string.Empty;

				ClaimsPrincipal principal = GetPrincipal(appSettings, token);

				if (principal is null)
					throw new ArgumentNullException(nameof(principal));

				var claimsIdentity = principal.Identity as ClaimsIdentity;

				var claim = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;

				if(claim is null)
					throw new ArgumentNullException(nameof(claim));

				return claim;
			}
			catch
			{
				throw;
			}

		}

	}
}
