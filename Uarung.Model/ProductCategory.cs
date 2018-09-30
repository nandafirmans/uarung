using System.Collections.Generic;
using Newtonsoft.Json;

namespace Uarung.Model
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            Products = new List<Product>();
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("products")]
        public List<Product> Products { get; set; }
    }
}