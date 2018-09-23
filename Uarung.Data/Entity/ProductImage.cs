using System;
using System.ComponentModel.DataAnnotations;
using Uarung.Data.Contract;

namespace Uarung.Data.Entity
{
    public class ProductImage : IEntityBase
    {
        [Key]
        public string Id { get; set; }

        public string Url { get; set; }

        public Product Product { get; set; }

        public string ProductId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
