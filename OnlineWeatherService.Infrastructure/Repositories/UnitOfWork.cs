using Microsoft.Extensions.Logging;
using OnlineWeatherService.Core.IRepositories;
using OnlineWeatherService.Infrastructure.Persistence;

namespace OnlineWeatherService.Infrastructure.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly WeatherDbContext _weatherDbContext;
		private readonly ILogger<WeatherRepository> _weatherLogger;
		private readonly ILogger<UserRepository> _userLogger;

		private bool _dispose = false;
		public UnitOfWork(WeatherDbContext weatherDbContext, ILogger<WeatherRepository> weatherLogger, ILogger<UserRepository> userLogger) => (_weatherDbContext, _weatherLogger, _userLogger) = (weatherDbContext, weatherLogger, userLogger);

		private readonly IWeatherRepository _weatherRepository;
		public IWeatherRepository WeatherkRepository
		{
			get
			{
				return _weatherRepository ?? new WeatherRepository(_weatherDbContext, _weatherLogger);
			}
		}

		private readonly IUserRepository _userRepository;
		public IUserRepository UserRepository
		{
			get
			{
				return _userRepository ?? new UserRepository(_weatherDbContext, _userLogger);
			}
		}

		public void Dispose(bool disposing)
		{
			if (!_dispose)
			{
				if (disposing)
				{
					_weatherDbContext.Dispose();
				}
				_dispose = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public async Task<int> SaveAsync()
		{
			return await _weatherDbContext.SaveChangesAsync();
		}
	}
}
