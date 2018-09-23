using Uarung.Data.Contract;
using Uarung.Data.Entity;
using Uarung.Data.Provider;

namespace Uarung.Data.DataAccess
{
    public class DacUser : BaseDataAccess<User>, IDacUser
    {
        public DacUser(DataContext context) : base(context)
        {
        }
    }
}