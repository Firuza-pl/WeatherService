using Microsoft.Extensions.Logging;
using OnlineWeatherService.Core.IRepositories;
using OnlineWeatherService.Infrastructure.Persistence;

namespace OnlineWeatherService.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WeatherDbContext _weatherDbContext;
        private readonly ILogger<WeatherRepository> _weatherLogger;
        private bool _dispose = false;
        public UnitOfWork(WeatherDbContext weatherDbContext, ILogger<WeatherRepository> weatherLogger) => (_weatherDbContext, _weatherLogger) = (weatherDbContext, weatherLogger);

        private readonly IWeatherRepository _weatherRepository;
        public IWeatherRepository WeatherkRepository
        {
            get
            {
                return _weatherRepository ?? new WeatherRepository(_weatherDbContext, _weatherLogger);
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
