using Newtonsoft.Json;

namespace Uarung.Model
{
    public class SelectedProduct
    {
        public SelectedProduct()
        {
            Product = new Product();
        }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("totalPrice")]
        public decimal TotalPrice { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("product")]
        public Product Product { get; set; }
    }
}