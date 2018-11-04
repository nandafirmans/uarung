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
        [MaxLength(50)]
        [Column("TransactionId")]
        public string Id { get; set; }

        [MaxLength(10)]
        public string PaymentType { get; set; }

        [MaxLength(10)]
        public string PaymentStatus { get; set; }

        public decimal TotalPrice { get; set; }

        [MaxLength(50)]
        public string DiscountCode { get; set; }

        public decimal DiscountValue { get; set; }

        [MaxLength(200)]
        public string Notes { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [MaxLength(50)]
        public string UserId { get; set; }

        public List<SelectedProduct> SelectedProducts { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
