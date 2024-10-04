﻿namespace OnlineWeatherService.SharedKernel.Core
{
    public class Entity
    {
        public Guid Id { get; protected set; }
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
