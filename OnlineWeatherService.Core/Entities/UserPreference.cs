﻿using OnlineWeatherService.SharedKernel.Core;

namespace OnlineWeatherService.Core.Entities
{
    public class UserPreference : Entity //actions that user can customize based on their needs
    {
        public Guid UserId { get; private set; }
        public string? PreferredCity { get; private set; }  //set default city for update
    }
}
