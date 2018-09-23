using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Id { get; set; }

        public string Name { get; set; }

        public List<Product> Products { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }


}
