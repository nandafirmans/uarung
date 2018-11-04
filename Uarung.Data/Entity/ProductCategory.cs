using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Uarung.Data.Contract;

namespace Uarung.Data.Entity
{
    public class ProductCategory : IEntityBase
    {
        public ProductCategory()
        {
            Products = new List<Product>();
        }

        [Key]
        [MaxLength(50)]
        [Column("CategoryId")]
        public string Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }


}
