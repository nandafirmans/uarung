using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Uarung.Data.Contract;

namespace Uarung.Data.Entity
{
    public class SelectedProduct : IEntityBase
    {
        [Key]
        [MaxLength(50)]
        [Column("SelectedId")]
        public string Id { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        [MaxLength(50)]
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        [MaxLength(200)]
        public string Notes { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [MaxLength(50)]
        public string ProductId { get; set; }

        [ForeignKey("TransactionId")]
        public Transaction Transaction { get; set; }

        [MaxLength(50)]
        public string TransactionId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
