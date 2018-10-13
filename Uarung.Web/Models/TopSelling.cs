using Uarung.Model;

namespace Uarung.Web.Models
{
    public class TopSelling
    {
        public TopSelling()
        {
            Product = new Product();
        }

        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}