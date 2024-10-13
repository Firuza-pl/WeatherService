using OnlineWeatherService.Application.DTO;
using OnlineWeatherService.Application.IServices;
using OnlineWeatherService.WCF.IServices;
using OnlineWeatherService.WCF.Models.Request;
using OnlineWeatherService.WCF.Models.Response;
using System.ServiceModel;

namespace OnlineWeatherService.WCF.Services
{
	public class UserSoapService : IUserSoapService
	{
		private readonly IUserService _userService;
		public UserSoapService(IUserService userService)
		{
			_userService = userService ?? throw new ArgumentNullException(nameof(userService));
		}

		public async Task<List<UserResponse>> GetAllUser()
		{
			try
			{
				var entity = await _userService.GetAllAsync();
				if (entity is null)
					throw new FaultException<ServiceFault>(new ServiceFault("data not found", 404));

				//var outputModel = new List<UserResponse>();
				//foreach (var item in entity) {
				//	outputModel.Add(new UserResponse
				//	{
				//		Name = item.Name,
				//	});
				//}

				var outputModel = entity.Select(x => new UserResponse
				{
					Name = x.Name,
					Surname = x.Surname,
					Gender = x.Gender,
					Email = x.Email,
					Birthday = x.Birthday,
					RefreshToken = x.RefreshToken
				}).ToList();

				return outputModel;
			}
			catch (Exception ex)
			{
				throw new FaultException<ServiceFault>(new ServiceFault(ex.Message, 500));
			}
		}

		public async Task<UserResponse> UserLogin(LoginRequest loginRequest)
		{
			try
			{

				if (loginRequest == null)
					throw new ArgumentNullException(nameof(loginRequest));

				var request = new LoginInputDTO { Password = loginRequest.Password, PhoneNumber = loginRequest.PhoneNumber };

				var entity = await _userService.GetLoginAsync(request);

				var responseDTO = new UserResponse
				{
					Name = entity.Name,
					Surname = entity.Surname,
					Gender = entity.Gender,
					Email = entity.Email,
					PhoneNumber = entity.PhoneNumber,
					RefreshToken = entity.RefreshToken
				};

				return responseDTO;
			}
			catch (Exception ex)
			{
				throw new FaultException<ServiceFault>(new ServiceFault(ex.Message, 500));
			}
		}
	}
}
