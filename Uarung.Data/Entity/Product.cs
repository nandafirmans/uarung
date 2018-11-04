using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Uarung.Data.Contract;

namespace Uarung.Data.Entity
{
    public class Product : IEntityBase
    {
        public Product()
        {
            ProductImages = new List<ProductImage>();
        }

        [Key]
        [MaxLength(50)]
        [Column("ProductId")]
        public string Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("CategoryId")]
        public ProductCategory ProductCategory { get; set; }

        [MaxLength(50)]
        public string CategoryId { get; set; }

        public List<ProductImage> ProductImages { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [MaxLength(50)]
        public string UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
