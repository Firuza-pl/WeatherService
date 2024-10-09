
using OnlineWeatherService.Application.DTO;

namespace OnlineWeatherService.Application.IServices
{
    public interface IUserService
    {
        Task<UserDTO> GetAllAsync();
    }
}
