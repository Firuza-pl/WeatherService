using Microsoft.Extensions.Caching.Memory;

namespace OnlineWeatherService.SharedKernel.Caching
{
    public class WeatherCache
    {
        private readonly IMemoryCache _cache;

        public WeatherCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public T Get<T>(string key)
        {
            _cache.TryGetValue(key, out T value);
            return value;
        }

        public void Set<T>(string key, T value, TimeSpan duration)
        {
            _cache.Set(key, value, duration);
        }
    }
}
