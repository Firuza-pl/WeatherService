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
        public async Task<WeatherDTO> GetWeatherAsync(CreateWeatherDTO request)
        {
            var entity = await _unitOfWork.WeatherkRepository.GetWeatherAsync(request.City);
            var outputModel = _mapper.Map<WeatherDTO>(entity);
            return outputModel;
        }

        public async Task<ForecastDTO> GetWeeklyForecastAsync(CreateForecastDTO request)
        {
            var entity = await _unitOfWork.WeatherkRepository.GetForeactWeeklyAsync(request.City);

            //return new ForecastDTO
            //{
            //    City = entity.City,
            //    DailyForecasts = entity.DailyForecasts.Select(p => new WeatherDTO
            //    {
            //        City = p.City,
            //        Description = p.Description,
            //        Temperature = p.Temperature
            //    }).ToList()
            //};

            var outputModel = _mapper.Map<ForecastDTO>(entity);
            return outputModel;
        }

    }
}
