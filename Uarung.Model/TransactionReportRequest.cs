using System;
using Newtonsoft.Json;

namespace Uarung.Model
{
    public class TransactionReportRequest
    {
        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }

        [JsonProperty("paymentStatus")]
        public string PaymentStatus { get; set; }
    }
}