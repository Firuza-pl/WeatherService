using OnlineWeatherService.Core.Entities;

namespace OnlineWeatherService.Core.IRepositories
{
    public interface IWeatherRepository : IGenericRepository<Weather>
    {
        //additional methods
        Task<Weather> GetWeatherAsync(string name);
        Task<Forecast> GetForeactWeeklyAsync(string name);
    }
}
