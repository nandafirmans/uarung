using Newtonsoft.Json;

namespace Uarung.Model
{
    public class BaseReponse 
    {
        public BaseReponse()
        {
            Status = new Status();
        }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}