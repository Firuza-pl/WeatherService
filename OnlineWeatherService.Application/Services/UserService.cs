using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using OnlineWeatherService.Application.DTO;
using OnlineWeatherService.Application.IServices;
using OnlineWeatherService.Core.IRepositories;

namespace OnlineWeatherService.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IMemoryCache _weatherCache;
		private readonly ILogger<UserService> _logger;


		public UserService(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache weatherCache, ILogger<UserService> logger)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(_unitOfWork));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
			_weatherCache = weatherCache ?? throw new ArgumentNullException(nameof(_weatherCache));
			_logger = logger ?? throw new ArgumentNullException(nameof(_logger));
		}

		public Task<UserDTO> GetAllAsync()
		{
			throw new NotImplementedException();
		}
	}


}
