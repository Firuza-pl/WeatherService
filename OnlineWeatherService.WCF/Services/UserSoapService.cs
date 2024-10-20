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
					AccessToken = entity.AccessToken
				};

				return responseDTO;
			}
			catch (Exception ex)
			{
				throw new FaultException<ServiceFault>(new ServiceFault(ex.Message, 500), new FaultReason(ex.Message));
			}
		}

		public async Task<UserResponse> UserRegister(RegisterRequest registerRequest)
		{
			try
			{
				if (registerRequest == null)
					throw new ArgumentNullException(nameof(registerRequest));

				var request = new RegisterInputDTO {
				Name = registerRequest.Name,
				Surname=registerRequest.Surname,
				PhoneNumber=registerRequest.PhoneNumber,
				Password = registerRequest.Password,
				Gender = registerRequest.Gender,
				Email = registerRequest.Email,
				Status = registerRequest.Status,
				Birthday = registerRequest.Birthday
				};

				var entity = await _userService.RegisterAsync(request);

				var responseDTO = new UserResponse
				{
					Name = entity.Name,
					Surname = entity.Surname,
					Gender = entity.Gender,
					Email = entity.Email,
					PhoneNumber = entity.PhoneNumber,
				};

				return responseDTO;
			}
			catch (Exception ex)
			{
				throw new FaultException<ServiceFault>(new ServiceFault(ex.Message, 500), new FaultReason(ex.Message));
			}
		}

		public async Task<bool> ValidateToken(VerifyTokenRequest loginRequest)
		{
			try
			{
				var model = new VerifyTokenDTO
				{
					PhoneNumber = loginRequest.PhoneNumber,
					Token = loginRequest.Token
				};

				var entity = await _userService.ValidateTokenAsync(model);
				if (entity is false)
					throw new ArgumentNullException(nameof(entity));

				return true;
			}
			catch (Exception ex)
			{
				throw new FaultException<ServiceFault>(new ServiceFault(ex.Message, 500));
			}
		}
	}
}
