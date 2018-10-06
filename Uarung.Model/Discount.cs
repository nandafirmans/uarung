using Newtonsoft.Json;

namespace Uarung.Model
{
    public class Discount
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}