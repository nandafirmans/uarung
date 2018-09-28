using Newtonsoft.Json;

namespace Uarung.API.Model
{
    public class LoginRequest 
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}