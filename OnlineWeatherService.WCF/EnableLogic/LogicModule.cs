using OnlineWeatherService.Application.IServices;
using OnlineWeatherService.Application.Services;
using OnlineWeatherService.Core.IRepositories;
using OnlineWeatherService.Infrastructure.Repositories;
using OnlineWeatherService.WCF.IServices;
using OnlineWeatherService.WCF.Services;

namespace OnlineWeatherService.WCF.EnableLogic
{
    public static class LogicModule
    {
        public static void LoadLogic(this IServiceCollection services)
        {
            services.AddScoped<IWeatherSoapService, WeatherSoapService>();
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddScoped<IWeatherRepository, WeatherRepository>();

            services.AddScoped<IUserSoapService, UserSoapService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            //general
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }

    }
}
