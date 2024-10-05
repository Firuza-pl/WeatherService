using System.Net;

namespace OnlineWeatherService.Response
{
    public class ApiResponse
    {
        public object Result { get; set; }
        public List<string> ErrorMessages { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccesed { get; set; }

        public ApiResponse()
        {
            ErrorMessages= new List<string>();
        }
    }
}
