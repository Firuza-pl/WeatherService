using Microsoft.Extensions.Logging;
using OnlineWeatherService.Core.Entities;
using OnlineWeatherService.Core.IRepositories;
using OnlineWeatherService.Infrastructure.Persistence;

namespace OnlineWeatherService.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(WeatherDbContext weatherDbContext, ILogger<UserRepository> logger) : base(weatherDbContext, logger) { }
    }
}
