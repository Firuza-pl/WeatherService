﻿using AutoMapper;
using OnlineWeatherService.Application.DTO;
using OnlineWeatherService.Core.Entities;

namespace OnlineWeatherService.Infrastructure.AutoMapper
{
	public class UserProfile : Profile
	{
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}
