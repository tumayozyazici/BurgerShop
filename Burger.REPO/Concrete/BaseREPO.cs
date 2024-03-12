using Burger.DATA.Interfaces;
using Burger.REPO.Contexts;
using Burger.REPO.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Burger.REPO.Concrete
{
    public class BaseREPO<T> : IBaseREPO<T> where T : BaseEntity
    {
        private readonly BurgerDbContext _db;
        private DbSet<T> _table;

        public BaseREPO(BurgerDbContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _table.AnyAsync(expression);
        }

        public int Create(T entity)
        {
            _table.Add(entity);
            return _db.SaveChanges();
        }

        public int Delete(T entity)
        {
            _db.Entry<T>(entity).State = EntityState.Deleted;
            return _db.SaveChanges();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<TResult> GetFilteredFirstOrDefaultAsync<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null)
        {
            IQueryable<T> query = _table;

            if (join != null)
            {
                query = join(query);
            }

            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderBy != null)
            {
                return await orderBy(query).Select(select).FirstOrDefaultAsync();
            }

            else
            {
                return await query.Select(select).FirstOrDefaultAsync();
            }
        }

        public async Task<List<TResult>> GetFilteredListAsync<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null)
        {
            IQueryable<T> query = _table;

            if (join != null)
            {
                query = join(query);
            }

            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderBy != null)
            {
                return await orderBy(query).Select(select).ToListAsync();
            }
            else
            {
                return await query.Select(select).ToListAsync();
            }

        }

        public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> expression)
        {
            return await _table.Where(expression).ToListAsync();
        }

        public int Update(T entity)
        {
            _db.Entry<T>(entity).State = EntityState.Modified;
            return _db.SaveChanges();
        }
    }
}
