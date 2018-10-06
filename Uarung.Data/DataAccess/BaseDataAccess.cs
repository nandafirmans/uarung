using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Uarung.Data.Contract;
using Uarung.Data.Provider;

namespace Uarung.Data.DataAccess
{
    public abstract class BaseDataAccess<T> : IBaseDataAccess<T> where T : class
    {
        private readonly DataContext _context;

        protected BaseDataAccess(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<T> All()
        {
            return _context.Set<T>();
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public T Single(string id)
        {
            return _context.Set<T>().FirstOrDefault(e => ((IEntityBase) e).Id.Equals(id));
        }

        public Task<T> SingleAsync(string id)
        {
            return _context.Set<T>().FirstOrDefaultAsync(e => ((IEntityBase) e).Id.Equals(id));
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public async Task<T> SingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public T InsertThenGet(T entity)
        {
            _context.Set<T>().Add(entity);

            return _context.Entry(entity).Entity;
        }

        public void Update(T entity)
        {
            var entityEntry = _context.Entry(entity);
            entityEntry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var entityEntry = _context.Entry(entity);
            entityEntry.State = EntityState.Deleted;
        }

        public void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            var entities = _context.Set<T>().Where(predicate);

            foreach (var entity in entities)
                _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}