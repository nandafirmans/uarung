using Uarung.Data.Contract;
using Uarung.Data.Entity;
using Uarung.Data.Provider;

namespace Uarung.Data.DataAccess
{
    public class DacProduct : BaseDataAccess<Product>, IDacProduct
    {
        public DacProduct(DataContext context) : base(context)
        {
        }
    }
}