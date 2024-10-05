using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineWeatherService.Core.Entities;
using OnlineWeatherService.Core.IRepositories;
using OnlineWeatherService.Infrastructure.Persistence;

namespace OnlineWeatherService.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly WeatherDbContext _dbContext;
        protected readonly ILogger<GenericRepository<T>> _logger;

        public GenericRepository(WeatherDbContext dbContext, ILogger<GenericRepository<T>> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public DbSet<T> Entity => _dbContext.Set<T>();

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await Entity.ToListAsync();
            return result;
        }

        public async Task<T> GetAsync(Guid id)
        {
            var result = await Entity.FindAsync(id);
            return result;
        }

        public async Task AddAsync(T entity)
        {
            await Entity.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            Entity.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            Entity.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

    }
}
