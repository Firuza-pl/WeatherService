namespace OnlineWeatherService.WCF.Models.Response
{
    public class WeatherResponse
    {
        public string? City { get; set; }
        public string? Description { get; set; }
        public decimal? Temperature { get; set; }
    }
}
