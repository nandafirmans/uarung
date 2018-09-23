using Uarung.Data.Contract;
using Uarung.Data.Entity;
using Uarung.Data.Provider;

namespace Uarung.Data.DataAccess
{
    public class DacTransaction : BaseDataAccess<Transaction>, IDacTransaction
    {
        public DacTransaction(DataContext context) : base(context)
        {
        }
    }
}