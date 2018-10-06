using Newtonsoft.Json;

namespace Uarung.Model
{
    public class ProductRequest : Product
    {
        [JsonProperty("categoryId")]
        public string CategoryId { get; set; }
    }
}