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

		//additional methods
		public async Task<Forecast> GetForeactWeeklyAsync(string name)
		{

			try
			{
				if (name is null) throw new ArgumentNullException(nameof(name));

				return await _dbContext.Set<Forecast>().Include(p => p.DailyForecasts).FirstOrDefaultAsync(x => x.City == name);
			}
			catch (Exception ex)
			{

				throw new ArgumentNullException(nameof(ex.Message));
			}

		}

		public async Task<Weather> GetWeatherAsync(string name)
		{
			try
			{
				if (name is null) throw new ArgumentNullException(nameof(name));

				var entity = GetNameAsync(name);

				return await entity;  //Entity=_dbContext.Set<Weather>(). from GenericRepository class
			}
			catch (Exception ex)
			{

				throw new ArgumentNullException(nameof(ex.Message));
			}
		}
	}
}
