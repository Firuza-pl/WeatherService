﻿using Microsoft.AspNetCore.Mvc;
using OnlineWeatherService.Infrastructure.Repositories;
using OnlineWeatherService.Response;
using OnlineWeatherService.WCF.Services;
using ServiceReference1;
using System.Net;
using System.ServiceModel;

namespace OnlineWeatherService.Controllers
{
    public static class WeatherMinimalAPI
    {
        public static void WeatherEndPoint(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapGet("/api/GetWeather", async ([FromQuery] string name, [FromServices] WeatherSoapServiceClient client, ILogger<UnitOfWork> logger) =>
            {
                ApiResponse apiResponse = new();

                logger.LogInformation("Received request to get weather for city: {CityName}", name);

                try
                {
                    if (string.IsNullOrEmpty(name))
                    {
                        logger.LogWarning("City name was empty.");
                        return Results.BadRequest("empty name");
                    }

                    var result = await client.GetWeatherAsync(name);

                    if (result is null)
                    {
                        logger.LogWarning("Weather data not found for city: {CityName}", name);

                        apiResponse.ErrorMessages.Add("entity is null");
                        apiResponse.StatusCode = HttpStatusCode.BadRequest;
                        apiResponse.IsSuccesed = false;
                    }

                    logger.LogInformation("Successfully retrieved weather data for city: {CityName}", name);

                    apiResponse.Result = result.Body.GetWeatherResult;
                    apiResponse.StatusCode = HttpStatusCode.OK;
                    apiResponse.IsSuccesed = true;
                   

                    return Results.Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while getting weather data for city: {CityName}", name);
                    throw new FaultException<ServiceFault>(new ServiceFault(ex.Message, 400));
                }
            })
                .WithName("GetWeather")
                .Produces<ApiResponse>(200)
                .Produces<ApiResponse>(400)
                .Produces<ApiResponse>(500)
                .WithTags("Service");

            //2

            endpoint.MapGet("/api/GetForeactWeather", async ([FromQuery] string name, [FromServices] WeatherSoapServiceClient client, ILogger<UnitOfWork> logger) =>
            {
                ApiResponse apiResponse = new();

                logger.LogInformation("Received request to get weather for city: {CityName}", name);

                try
                {
                    if (string.IsNullOrEmpty(name))
                    {
                        logger.LogWarning("City name was empty.");
                        return Results.BadRequest("empty name");
                    }

                    var result = await client.GetWeeklyForecastAsync(name);
					logger.LogInformation("Received response: {@Entity}", result);

					if (result is null)
                    {
                        logger.LogWarning("Weather data not found for city: {CityName}", name);

                        apiResponse.ErrorMessages.Add("entity is null");
                        apiResponse.StatusCode = HttpStatusCode.BadRequest;
                        apiResponse.IsSuccesed = false;
                    }

                    logger.LogInformation("Successfully retrieved weather data for city: {CityName}", name);

                    apiResponse.Result = result.Body.GetWeeklyForecastResult;
                    apiResponse.StatusCode = HttpStatusCode.OK;
                    apiResponse.IsSuccesed = true;


                    return Results.Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while getting weather data for city: {CityName}", name);
                    throw new FaultException<ServiceFault>(new ServiceFault(ex.Message, 400));
                }
            })
               .WithName("GeForecastWeather")
               .Produces<ApiResponse>(200)
               .Produces<ApiResponse>(400)
               .Produces<ApiResponse>(500)
               .WithTags("Service");


        }
    }
}
