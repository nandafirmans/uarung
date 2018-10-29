using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Uarung.Data.Entity;

namespace Uarung.Data.Contract
{
    public interface IBaseDataAccess<T> where T : class
    {
        IEnumerable<T> All();

        IEnumerable<T> Where(Expression<Func<T, bool>> predicate);

        int Count();

        int Count(Expression<Func<T, bool>> expression);

        T Single(string id);

        Task<T> SingleAsync(string keyValue);

        T Single(Expression<Func<T, bool>> predicate);

        Task<T> SingleAsync(Expression<Func<T, bool>> predicate);

        void Insert(T entity);

        T InsertThenGet(T entity);

        void Update(T entity);

        void Delete(T entity);

        void DeleteWhere(Expression<Func<T, bool>> predicate);

        void Commit();

        void Dispose();
    }

    public interface IDacProduct : IBaseDataAccess<Product> {}

    public interface IDacProductCategory : IBaseDataAccess<ProductCategory> {}

    public interface IDacProductImage : IBaseDataAccess<ProductImage> {}

    public interface IDacTransaction : IBaseDataAccess<Transaction> {}

    public interface IDacSelectedProduct : IBaseDataAccess<SelectedProduct> {}

    public interface IDacDiscount : IBaseDataAccess<Discount> {}

    public interface IDacUser : IBaseDataAccess<User> {}
}
