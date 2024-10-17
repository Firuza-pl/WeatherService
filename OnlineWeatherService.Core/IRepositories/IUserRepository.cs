using Microsoft.AspNetCore.Identity;
using OnlineWeatherService.Core.Entities;

namespace OnlineWeatherService.Core.IRepositories
{
	public interface IUserRepository : IGenericRepository<ApplicationUser>
	{
		public Task<ApplicationUser> GetUserByPhoneAsync(string phoneNumber);
		public Task<IdentityResult> CreateRoleUser(ApplicationUser user, string password);
		public Task<bool> CheckDublicate(string phoneNumber);
	}
}
