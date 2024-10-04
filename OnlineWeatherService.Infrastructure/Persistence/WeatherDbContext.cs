using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineWeatherService.Core.Entities;
using System;

namespace OnlineWeatherService.Infrastructure.Persistence
{
    public class WeatherDbContext : IdentityDbContext<ApplicationUser>
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        {

        }
      
        DbSet<Weather> Weathers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
