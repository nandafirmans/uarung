using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Uarung.Data.Contract;

namespace Uarung.Data.Entity
{
    public class Discount : IEntityBase
    {
        [Key]
        [MaxLength(50)]
        [Column("DiscountCode")]
        public string Id { get; set; }

        [MaxLength(15)]
        public string Type { get; set; }

        public decimal Value { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [MaxLength(50)]
        public string UserId { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
