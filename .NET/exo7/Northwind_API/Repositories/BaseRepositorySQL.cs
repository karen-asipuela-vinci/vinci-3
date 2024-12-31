using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Northwind_API.Repositories
{
    public class BaseRepositorySQL<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        public BaseRepositorySQL(DbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await SaveChangesAsync();
        }

        public async Task<IList<T>> SearchForAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<bool?> SaveAsync(T entity, Expression<Func<T, bool>> predicate)
        {
            var exists = await _context.Set<T>().AnyAsync(predicate);
            if (!exists)
            {
                await InsertAsync(entity);
                return true;
            }
            return false;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        private async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException(e.InnerException?.Message ?? e.Message);
            }
        }
    }
}
