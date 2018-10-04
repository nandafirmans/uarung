using Newtonsoft.Json;

namespace Uarung.Model
{
    public class LoginResponse : BaseReponse
    {
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}