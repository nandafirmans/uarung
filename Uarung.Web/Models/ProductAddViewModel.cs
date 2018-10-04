using System.Collections.Generic;
using Uarung.Model;

namespace Uarung.Web.Models
{
    public class ProductAddViewModel
    {
        public ProductAddViewModel()
        {
            Categories = new List<ProductCategory>();    
        }

        public List<ProductCategory> Categories { get; set; }
    }
}