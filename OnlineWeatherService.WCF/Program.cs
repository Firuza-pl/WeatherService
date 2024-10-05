using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineWeatherService.Core.Entities;
using OnlineWeatherService.Infrastructure.AutoMapper;
using OnlineWeatherService.Infrastructure.Persistence;
using OnlineWeatherService.WCF.EnableLogic;
using OnlineWeatherService.WCF.IServices;
using OnlineWeatherService.WCF.Services;
using SoapCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WeatherDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<WeatherDbContext>().AddDefaultTokenProviders();


builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // or any other logging provider
builder.Services.AddLogging();

//register serivce
builder.Services.AddSingleton(AutoMapperConfig.CreateMapper());
builder.Services.LoadLogic();


var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<IWeatherSoapService>("/WeatherSoapService.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);   ///WeatherSoapService.asmx
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();

