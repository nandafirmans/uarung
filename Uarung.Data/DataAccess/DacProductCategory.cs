using Uarung.Data.Contract;
using Uarung.Data.Entity;
using Uarung.Data.Provider;

namespace Uarung.Data.DataAccess
{
    public class DacProductCategory : BaseDataAccess<ProductCategory>, IDacProductCategory
    {
        public DacProductCategory(DataContext context) : base(context)
        {
        }
    }
}