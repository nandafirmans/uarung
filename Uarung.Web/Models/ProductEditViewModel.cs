using Uarung.Model;

namespace Uarung.Web.Models
{
    public class ProductEditViewModel : ProductAddViewModel
    {
        public ProductEditViewModel()
        {
            Product = new Product();
        }

        public Product Product { get; set; }
    }
}