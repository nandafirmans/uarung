using Newtonsoft.Json;

namespace Uarung.Model
{
    public class LoginResponse : BaseResponse
    {
        public LoginResponse()
        {
            User = new User();
        }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}