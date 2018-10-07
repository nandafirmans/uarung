using System.Collections.Generic;
using Uarung.Model;

namespace Uarung.Web.Models
{
    public class SalesRegisterViewModel
    {
        public SalesRegisterViewModel()
        {
            Products = new List<Product>();
            Categories = new List<ProductCategory>();
        }

        public List<Product> Products { get; set; }

        public List<ProductCategory> Categories { get; set; }
    }
}