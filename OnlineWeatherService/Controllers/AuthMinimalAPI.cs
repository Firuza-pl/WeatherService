using AuthReferences;
using Microsoft.AspNetCore.Mvc;
using OnlineWeatherService.Infrastructure.Repositories;
using OnlineWeatherService.Response;
using OnlineWeatherService.WCF.Services;
using System.Net;
using System.ServiceModel;

namespace OnlineWeatherService.Controllers
{
	public static class AuthMinimalAPI
	{
		public static void AuthEndPoint(this IEndpointRouteBuilder endpoint)
		{
			endpoint.MapGet("/api/GetUser", async ([FromServices] UserSoapServiceClient client, ILogger<UnitOfWork> logger) =>
			{
				ApiResponse apiResponse = new();

				try
				{

					var result = await client.GetAllUserAsync();

					if (result is null)
					{
						logger.LogWarning("User data not found");

						apiResponse.ErrorMessages.Add("entity is null");
						apiResponse.StatusCode = HttpStatusCode.BadRequest;
						apiResponse.IsSuccesed = false;
					}

					logger.LogInformation("Successfully retrieved data");

					apiResponse.Result = result;
					apiResponse.StatusCode = HttpStatusCode.OK;
					apiResponse.IsSuccesed = true;


					return Results.Ok(apiResponse);
				}
				catch (Exception ex)
				{
					logger.LogError(ex, "An error occurred while getting data");
					throw new FaultException<ServiceFault>(new ServiceFault(ex.Message, 400), new FaultReason(ex.Message));
				}
			})
				.WithName("GetUser")
				.Produces<ApiResponse>(200)
				.Produces<ApiResponse>(400)
				.Produces<ApiResponse>(500)
				.WithTags("Auth");


			//login
			endpoint.MapPost("/api/Login", async ([FromServices] UserSoapServiceClient client, ILogger<UnitOfWork> logger, [FromBody] LoginRequest loginRequest) =>
			{
				ApiResponse apiResponse = new();

				try
				{

					var result = await client.UserLoginAsync(loginRequest);

					if (result is null)
					{
						logger.LogWarning("User data not found");

						apiResponse.ErrorMessages.Add("entity is null");
						apiResponse.StatusCode = HttpStatusCode.BadRequest;
						apiResponse.IsSuccesed = false;
					}

					logger.LogInformation("Successfully retrieved data");

					apiResponse.Result = result;
					apiResponse.StatusCode = HttpStatusCode.OK;
					apiResponse.IsSuccesed = true;


					return Results.Ok(apiResponse);
				}
				catch (Exception ex)
				{
					logger.LogError(ex, "An error occurred while getting data");
					throw new FaultException<ServiceFault>(new ServiceFault(ex.Message, 400), new FaultReason(ex.Message));
				}
			})
				.WithName("UserLogin")
				.Produces<ApiResponse>(200)
				.Produces<ApiResponse>(400)
				.Produces<ApiResponse>(500)
				.WithTags("Auth");


			//register 

			endpoint.MapPost("/api/Register", async ([FromServices] UserSoapServiceClient client, ILogger<UnitOfWork> logger, [FromBody] LoginRequest loginRequest) =>
				{
					ApiResponse apiResponse = new();

					try
					{

						var result = await client.UserLoginAsync(loginRequest);

						if (result is null)
						{
							logger.LogWarning("User data not found");

							apiResponse.ErrorMessages.Add("entity is null");
							apiResponse.StatusCode = HttpStatusCode.BadRequest;
							apiResponse.IsSuccesed = false;
						}

						logger.LogInformation("Successfully retrieved data");

						apiResponse.Result = result;
						apiResponse.StatusCode = HttpStatusCode.OK;
						apiResponse.IsSuccesed = true;


						return Results.Ok(apiResponse);
					}
					catch (Exception ex)
					{
						logger.LogError(ex, "An error occurred while getting data");
						throw new FaultException<ServiceFault>(new ServiceFault(ex.Message, 400), new FaultReason(ex.Message));
					}
				})
					.WithName("UserRegister")
					.Produces<ApiResponse>(200)
					.Produces<ApiResponse>(400)
					.Produces<ApiResponse>(500)
					.WithTags("Auth");
		}
	}
}
