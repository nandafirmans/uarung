using Newtonsoft.Json;

namespace Uarung.Model
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("gender")]
        public char Gender { get; set; }
    }
}