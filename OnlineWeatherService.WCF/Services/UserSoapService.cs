using OnlineWeatherService.Application.IServices;
using OnlineWeatherService.WCF.IServices;
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

		public  async Task<UserResponse> GetAllUser()
		{
			try
			{
				var entity = await _userService.GetAllAsync();
				if (entity is null)
					throw new FaultException<ServiceFault>(new ServiceFault("data not found", 404));

				var outputModel = new UserResponse
				{
					Name = entity.Name,
					Surname = entity.Surname,
					Gender = entity.Gender
				};

				return outputModel;
			}
			catch (Exception ex)
			{
				throw new FaultException<ServiceFault>(new ServiceFault(ex.Message, 500));
			}
		}
	}
}
