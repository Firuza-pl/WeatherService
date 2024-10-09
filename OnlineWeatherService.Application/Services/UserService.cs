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
		private readonly IMemoryCache _cache;
		private readonly ILogger<UserService> _logger;


		public UserService(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache cache, ILogger<UserService> logger)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(_unitOfWork));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
			_cache = cache ?? throw new ArgumentNullException(nameof(_cache));
			_logger = logger ?? throw new ArgumentNullException(nameof(_logger));
		}

		public async Task<UserDTO> GetAllAsync()
		{
			try
			{
				_logger.LogInformation("Getting all users");

				var entity = await _unitOfWork.UserRepository.GetAllAsync();
				var outputModel = _mapper.Map<UserDTO>(entity);

				if (outputModel == null)
				{
					_logger.LogWarning("No data found");
				}

				return outputModel;
			}
			catch (Exception ex)
			{
				throw new ArgumentNullException(nameof(ex));
			}
		}
	}


}
