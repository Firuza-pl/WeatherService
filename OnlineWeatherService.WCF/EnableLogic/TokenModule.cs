using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OnlineWeatherService.Application.Helper;
using System.Text;

namespace OnlineWeatherService.WCF.EnableLogic
{
	public static class TokenModule
	{
		public static void JwtLoad(this IServiceCollection services, IConfiguration configuration)
		{
			var appSettingConfiguration = configuration.GetSection("AppSettings");
			var appSettingService = services.Configure<AppSettings>(appSettingConfiguration);

			var appSettingField = appSettingConfiguration.Get<AppSettings>();
			var secretKey = Encoding.ASCII.GetBytes(appSettingField.Secret);


			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(x =>
				{
					x.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						RequireExpirationTime = true,
						IssuerSigningKey = new SymmetricSecurityKey(secretKey),
						ValidateIssuerSigningKey = true
					};
					x.RequireHttpsMetadata = false;
					x.SaveToken = true;
				});

		}
	}
}
