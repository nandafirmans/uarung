using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Uarung.Data.Contract;

namespace Uarung.Data.Entity
{
    public class ProductImage : IEntityBase
    {
        [Key]
        [MaxLength(50)]
        [Column("ImageId")]
        public string Id { get; set; }

        public string Url { get; set; }

        public Product Product { get; set; }

        [MaxLength(50)]
        public string ProductId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
