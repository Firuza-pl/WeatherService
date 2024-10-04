using Microsoft.AspNetCore.Identity;

namespace OnlineWeatherService.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? Birthday { get; set; }
        public byte? Status { get; set; }
        public byte? Gender { get; set; }
        public List<UserPreference>? Preferences { get; set; }
    }
}
