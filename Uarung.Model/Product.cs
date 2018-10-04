using System.Collections.Generic;
using Newtonsoft.Json;

namespace Uarung.Model
{
    public class Product
    {
        public Product()
        {
            Images = new List<string>();
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("images")]
        public List<string> Images { get; set; }

        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }
    }
}