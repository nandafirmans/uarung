using Uarung.Data.Contract;
using Uarung.Data.Entity;
using Uarung.Data.Provider;

namespace Uarung.Data.DataAccess
{
    public class DacDiscount : BaseDataAccess<Discount>, IDacDiscount
    {
        public DacDiscount(DataContext context) : base(context)
        {
        }
    }
}