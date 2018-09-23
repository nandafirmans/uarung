using Uarung.Data.Contract;
using Uarung.Data.Entity;
using Uarung.Data.Provider;

namespace Uarung.Data.DataAccess
{
    public class DacProductImage : BaseDataAccess<ProductImage>, IDacProductImage
    {
        public DacProductImage(DataContext context) : base(context)
        {
        }
    }
}