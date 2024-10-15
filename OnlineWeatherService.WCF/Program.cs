using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineWeatherService.Core.Entities;
using OnlineWeatherService.Infrastructure.AutoMapper;
using OnlineWeatherService.Infrastructure.Persistence;
using OnlineWeatherService.WCF.EnableLogic;
using OnlineWeatherService.WCF.IServices;
using OnlineWeatherService.SharedKernel.Logging;
using SoapCore;
using Serilog;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OnlineWeatherService.WCF.Services;
using OnlineWeatherService.Application.Helper;
using SoapCore.Extensibility;

//WCF SERVICE

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddDbContext<WeatherDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

    // Add memory cache services
    builder.Services.AddMemoryCache();

    builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<WeatherDbContext>().AddDefaultTokenProviders();

	builder.Services.AddSoapCore();

	//register serivce
	builder.Services.AddSingleton(AutoMapperConfig.CreateMapper());
    builder.Services.LoadLogic();
    builder.Services.ConfigureLogging();

    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();


    var app = builder.Build();

    app.UseRouting();
    app.UseEndpoints(endpoints =>
    {
        endpoints.UseSoapEndpoint<IWeatherSoapService>("/WeatherSoapService.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);   ///WeatherSoapService.asmx
        endpoints.UseSoapEndpoint<IUserSoapService>("/UserSoapService.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);   ///WeatherSoapService.asmx

	});


    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
    }

    app.UseHttpsRedirection();


    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}
