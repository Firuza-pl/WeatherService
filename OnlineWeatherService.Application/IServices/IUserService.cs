using OnlineWeatherService.Application.DTO;

namespace OnlineWeatherService.Application.IServices
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllAsync();
        Task<LoginOutputDTO> GetLoginAsync(LoginInputDTO loginInput);
		Task<RegisterOutputDTO> RegisterAsync(RegisterInputDTO loginInput);
	}
}
