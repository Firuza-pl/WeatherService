using AutoMapper;
using OnlineWeatherService.Application.DTO;
using OnlineWeatherService.Core.Entities;
namespace OnlineWeatherService.Infrastructure.AutoMapper
{
    public class WeatherProfile : Profile
    {
        public WeatherProfile()
        {
            CreateMap<Weather, WeatherDTO>().ReverseMap();
            CreateMap<Forecast, ForecastDTO>().ReverseMap()
                .ForMember(dest => dest.DailyForecasts, src => src.MapFrom(p => p.DailyForecasts));
        }
    }
}
