using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using OnlineWeatherService.Application.DTO;
using OnlineWeatherService.Application.IServices;
using OnlineWeatherService.Core.IRepositories;

namespace OnlineWeatherService.Application.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _weatherCache;
        private readonly ILogger<WeatherService> _logger;


        public WeatherService(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache weatherCache, ILogger<WeatherService> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(_unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
            _weatherCache = weatherCache ?? throw new ArgumentNullException(nameof(_weatherCache));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }
        public async Task<WeatherDTO> GetWeatherAsync(string name)
        {
            try
            {
                _logger.LogInformation("Fetching weather for {City}", name);

                if (_weatherCache.TryGetValue(name, out WeatherDTO cachedWeather))
                {
                    return cachedWeather;
                }

                var entity = await _unitOfWork.WeatherkRepository.GetWeatherAsync(name);

                var outputModel = _mapper.Map<WeatherDTO>(entity);

                if (outputModel == null)
                {
                    _logger.LogWarning("No weather data found for {City}", name);
                }

                _weatherCache.Set(name, outputModel, TimeSpan.FromMinutes(5)); // Store the result in cache with 

                return outputModel;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public async Task<ForecastDTO> GetWeeklyForecastAsync(string name)
        {
            try
            {
				_logger.LogInformation("Fetching weather for {City}", name);

				if (_weatherCache.TryGetValue(name, out ForecastDTO cachedForecast))
				{
					return cachedForecast;
				}
				var entity = await _unitOfWork.WeatherkRepository.GetForeactWeeklyAsync(name);

				var outputModel = _mapper.Map<ForecastDTO>(entity);

				if (outputModel == null)
				{
					_logger.LogWarning("No weather data found for {City}", name);
				}

				return outputModel;
			}
            catch (Exception)
            {

                throw;
            }
        }

    }
}
