﻿using AutoMapper;
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
			_mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
		}

		//additional methods
		public async Task<ApplicationUser> GenerateRefreshToken(string phoneNumber)
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

		public async Task<bool> CheckPhoneNumber(string phoneNumber)
		{
			try
			{
				var user = await _userManager.Users.SingleOrDefaultAsync(x => x.PhoneNumber == phoneNumber);

				if (user is null)
					throw new ArgumentException($"{user} is already in db");

				return true;
			}
			catch (Exception ex)
			{
				throw new ArgumentException("User is in already db");
			}
		}

		public async Task<IdentityResult> CreateRoleUser(ApplicationUser user, string password)
		{
			try
			{
				var register = await _userManager.CreateAsync(user, password);
				if(register is null)
					throw new ArgumentNullException(nameof(register));

				await _userManager.AddToRoleAsync(user, Role.User);
				await _dbContext.SaveChangesAsync();

				return register;
			}
			catch (Exception ex)
			{
				throw ex ?? new ArgumentNullException(nameof(ex.Message));
			}

		}


	}
}
