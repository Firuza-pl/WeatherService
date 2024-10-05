using Microsoft.AspNetCore.Mvc;
using OnlineWeatherService.Response;
using OnlineWeatherService.WCF.Models.Request;
using OnlineWeatherService.WCF.Services;
using OnlineWeatherSoapService;
using System.Net;
using System.ServiceModel;

namespace OnlineWeatherService.Controllers
{
    public static class WeatherMinimalAPI
    {
        public static void WeatherEndPoint(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapGet("/api/GetWeather", async ([FromQuery] string name, [FromServices] WeatherSoapServiceClient client) =>
            {
                ApiResponse apiResponse = new();
                try
                {
                    if (string.IsNullOrEmpty(name))
                    {
                        return Results.BadRequest("empty name");
                    }

                    var result = await client.GetWeatherAsync(name);
                    if (result is { })
                    {
                        apiResponse.Result= result;
                        apiResponse.StatusCode = HttpStatusCode.OK;
                        apiResponse.IsSuccesed= true;
                    }

                    apiResponse.ErrorMessages.Add("entity is null");
                    apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    apiResponse.IsSuccesed = false;

                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    throw new FaultException<ServiceFault>(new ServiceFault(ex.Message, 400));
                }
            })
                .WithName("GetWeather")
                .Produces<ApiResponse>(200)
                .Produces<ApiResponse>(400)
                .Produces<ApiResponse>(500)
                .WithTags("Service");

        }
    }
}
