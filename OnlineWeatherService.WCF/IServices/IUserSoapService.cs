using OnlineWeatherService.WCF.Models.Request;
using OnlineWeatherService.WCF.Models.Response;
using System.ServiceModel;

namespace OnlineWeatherService.WCF.IServices
{
    [ServiceContract]
	public interface IUserSoapService
	{
		[OperationContract]
		Task<List<UserResponse>> GetAllUser();

		[OperationContract]
		Task<UserResponse> UserRegister(RegisterRequest registerRequest);

		[OperationContract]
		Task<UserResponse> UserLogin(LoginRequest loginRequest);

		[OperationContract]
		Task<bool> ValidateToken(VerifyTokenRequest loginRequest);

	}
}
