using Newtonsoft.Json;

namespace Uarung.Model
{
    public class UserRequest : User
    {
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}