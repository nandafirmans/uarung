using Uarung.Data.Contract;
using Uarung.Data.Entity;
using Uarung.Data.Provider;

namespace Uarung.Data.DataAccess
{
    public class DacSelectedProduct : BaseDataAccess<SelectedProduct>, IDacSelectedProduct
    {
        public DacSelectedProduct(DataContext context) : base(context)
        {
        }
    }
}