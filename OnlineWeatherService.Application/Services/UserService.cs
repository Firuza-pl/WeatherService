using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnlineWeatherService.Application.DTO;
using OnlineWeatherService.Application.Helper;
using OnlineWeatherService.Application.IServices;
using OnlineWeatherService.Core.Entities;
using OnlineWeatherService.Core.IRepositories;

namespace OnlineWeatherService.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IMemoryCache _cache;
		private readonly ILogger<UserService> _logger;
		private readonly AppSettings _appSettings;
		private readonly SignInManager<ApplicationUser> _signInManager;


		public UserService(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache cache, ILogger<UserService> logger,
			IOptions<AppSettings> appSettings, SignInManager<ApplicationUser> signInManager)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(_unitOfWork));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
			_cache = cache ?? throw new ArgumentNullException(nameof(_cache));
			_logger = logger ?? throw new ArgumentNullException(nameof(_logger));
			_appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(_appSettings));
			_signInManager = signInManager ?? throw new ArgumentNullException(nameof(_signInManager));
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

		public async Task<LoginOutputDTO> GetLoginAsync(LoginInputDTO loginInput)
		{
			var users = await _unitOfWork.UserRepository.GetUserByPhoneAsync(loginInput.PhoneNumber);
			if (users == null)
				throw new ArgumentNullException($"{nameof(users)}");

			var signedUser = await _signInManager.PasswordSignInAsync(users, loginInput.Password, false, true); 

			if (!signedUser.Succeeded)
				throw new UnauthorizedAccessException(nameof(signedUser));

			var accessToken = TokenConfiguration.CreateToken(_appSettings, users.Id, Role.User);

			var outputModel = _mapper.Map<LoginOutputDTO>(users);
			outputModel.AccessToken = accessToken;
			outputModel.RefreshToken = users.RefreshToken;

			return outputModel;
		}
	}


}
