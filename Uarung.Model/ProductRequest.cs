using Newtonsoft.Json;

namespace Uarung.Model
{
    public class ProductRequest : Product
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("categoryId")]
        public string CategoryId { get; set; }
    }
}