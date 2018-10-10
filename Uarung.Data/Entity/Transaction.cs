using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Uarung.Data.Contract;

namespace Uarung.Data.Entity
{
    public class Transaction : IEntityBase
    {
        public Transaction()
        {
            SelectedProducts = new List<SelectedProduct>();
        }

        [Key]
        public string Id { get; set; }

        public string PaymentType { get; set; }

        public string PaymentStatus { get; set; }

        public decimal TotalPrice { get; set; }

        public string DiscountCode { get; set; }

        public decimal DiscountValue { get; set; }

        public string Notes { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public string UserId { get; set; }

        public List<SelectedProduct> SelectedProducts { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
