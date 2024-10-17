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

		public async Task<List<UserDTO>> GetAllAsync()
		{
			try
			{
				_logger.LogInformation("Getting all users");

				var entity = await _unitOfWork.UserRepository.GetAllAsync();
				var outputModel = _mapper.Map<List<UserDTO>>(entity);

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
			try
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
			catch (Exception ex)
			{
				throw new ArgumentNullException(nameof(ex));
			}
		}


		public async Task<RegisterOutputDTO> RegisterAsync(RegisterInputDTO loginInput)
		{
			try
			{
				var isPhoneAlreadyRegistered = await _unitOfWork.UserRepository.CheckDublicate(loginInput.PhoneNumber);
				if (isPhoneAlreadyRegistered is true)
					throw new ArgumentException($"{isPhoneAlreadyRegistered} is already registered");

				var entity = _mapper.Map<ApplicationUser>(loginInput);
				entity.UserName = loginInput.PhoneNumber;
				entity.Status = (byte)loginInput.Status;

				var result = await _unitOfWork.UserRepository.CreateRoleUser(entity, loginInput.Password);
				var outputModel = _mapper.Map<ApplicationUser, RegisterOutputDTO>(entity);
				return outputModel;
			}
			catch (Exception ex)
			{
				throw new ArgumentNullException(nameof(ex.Message));
			}
		}

		public async Task<bool> ValidateTokenAsync(VerifyTokenDTO verifyTokenDTO)
		{
			var isPhoneAlreadyRegistered = await _unitOfWork.UserRepository.CheckDublicate(verifyTokenDTO.PhoneNumber);
			if (isPhoneAlreadyRegistered is true)
				throw new ArgumentException($"{isPhoneAlreadyRegistered} is already registered");

			var validateTokenId = TokenConfiguration.ValidateToken(_appSettings, verifyTokenDTO.Token);
			if (validateTokenId is null)
				throw new ArgumentException();

			return true;
		}
	}


}
