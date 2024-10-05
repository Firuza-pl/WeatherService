using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineWeatherService.Core.Entities;
using OnlineWeatherService.Core.IRepositories;
using OnlineWeatherService.Infrastructure.Persistence;

namespace OnlineWeatherService.Infrastructure.Repositories
{
    public class WeatherRepository : GenericRepository<Weather>, IWeatherRepository
    {
        public WeatherRepository(WeatherDbContext contex, ILogger<WeatherRepository> logger) : base(contex, logger)
        {

        }

        public async Task<Forecast> GetForeactWeeklyAsync(string name)
        {

            if (name is null) throw new ArgumentNullException(nameof(name));

            return await _dbContext.Set<Forecast>().FirstOrDefaultAsync(x => x.City == name);

        }

        public async Task<Weather> GetWeatherAsync(string name)
        {
            if (name is null) throw new ArgumentNullException(nameof(name));

            return await Entity.FirstOrDefaultAsync(x => x.City == name);  //Entity=_dbContext.Set<Weather>(). from GenericRepository class
        }
    }
}
