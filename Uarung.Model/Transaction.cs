using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Uarung.Model
{
    public class Transaction
    {
        public Transaction()
        {
            SelectedProducts = new List<SelectedProduct>();
            Discount = new Discount();
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("totalPrice")]
        public decimal TotalPrice { get; set; }

        [JsonProperty("paymentType")]
        public string PaymentType { get; set; }

        [JsonProperty("paymentStatus")]
        public string PaymentStatus { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("selectedProducts")]
        public List<SelectedProduct> SelectedProducts { get; set; }

        [JsonProperty("discount")]
        public Discount Discount { get; set; }
    }
}