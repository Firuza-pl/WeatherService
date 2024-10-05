using AutoMapper;
using OnlineWeatherService.Application.DTO;
using OnlineWeatherService.Application.IServices;
using OnlineWeatherService.Core.IRepositories;

namespace OnlineWeatherService.Application.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WeatherService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<WeatherDTO> GetWeatherAsync(string name)
        {
            var entity = await _unitOfWork.WeatherkRepository.GetWeatherAsync(name);
            var outputModel = _mapper.Map<WeatherDTO>(entity);
            return outputModel;
        }

        public async Task<ForecastDTO> GetWeeklyForecastAsync(string name)
        {
            var entity = await _unitOfWork.WeatherkRepository.GetForeactWeeklyAsync(name);

            var outputModel = _mapper.Map<ForecastDTO>(entity);
            return outputModel;
        }

    }
}
