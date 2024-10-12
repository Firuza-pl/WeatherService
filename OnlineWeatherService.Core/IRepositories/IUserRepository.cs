using OnlineWeatherService.Core.Entities;

namespace OnlineWeatherService.Core.IRepositories
{
	public interface IUserRepository : IGenericRepository<ApplicationUser>
	{
		public Task<ApplicationUser> GetUserByPhoneAsync(string phoneNumber);
		//ValidateAsync
		//LogOutAsync
	}
}
