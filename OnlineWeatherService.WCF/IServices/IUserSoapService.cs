using OnlineWeatherService.WCF.Models.Request;
using OnlineWeatherService.WCF.Models.Response;
using System.ServiceModel;

namespace OnlineWeatherService.WCF.IServices
{
    [ServiceContract]
	public interface IUserSoapService
	{
		[OperationContract]
		Task<UserResponse> GetAllUser();

		[OperationContract]
		Task<UserResponse> UserLogin(LoginRequest loginRequest);
	}
}
