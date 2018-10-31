using Newtonsoft.Json;

namespace Uarung.Model
{
    public class BaseResponse 
    {
        public BaseResponse()
        {
            Status = new Status();
        }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}