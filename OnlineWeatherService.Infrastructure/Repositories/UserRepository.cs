using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineWeatherService.Core.Entities;
using OnlineWeatherService.Core.IRepositories;
using OnlineWeatherService.Infrastructure.Persistence;
using System.Security.Cryptography;

namespace OnlineWeatherService.Infrastructure.Repositories
{
	public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IMapper _mapper;

		public UserRepository(WeatherDbContext weatherDbContext, ILogger<UserRepository> logger,
			UserManager<ApplicationUser> userManager, IMapper mapper) : base(weatherDbContext, logger)
		{
			_userManager = userManager ?? throw new ArgumentNullException(nameof(_userManager));
			_mapper = mapper;
		}


		public async Task<ApplicationUser> GetUserByPhoneAsync(string phoneNumber)
		{
			try
			{
				var user = await _userManager.Users.SingleOrDefaultAsync(p => p.PhoneNumber == phoneNumber);

				if (user == null)
					throw new ArgumentNullException(nameof(user));

				var randomNumber = GenerateRandomNumber();
				user.RefreshToken = $"{randomNumber}_{user.Id}_{user.PhoneNumber}";

				await _userManager.UpdateAsync(user);

				return user;
			}
			catch (Exception ex)
			{
				throw ex ?? new ArgumentNullException(nameof(ex.Message));
			}
		}

		public string GenerateRandomNumber()
		{
			var random = new byte[32];
			using var range = RandomNumberGenerator.Create();
			range.GetBytes(random);
			return Convert.ToBase64String(random);
		}



	}
}
