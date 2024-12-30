using _5_SchoolApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _5_SchoolApp.Repositories
{
    internal class BaseRepositorySQL<T> : IRepository<T> where T : class
    {
        private readonly SchoolContext _context;

        public BaseRepositorySQL(SchoolContext context)
        {
            _context = context;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            SaveChanges();
        }

        public IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            SaveChanges();
        }

        public bool Save(T entity, Expression<Func<T, bool>> predicate)
        {
            var exists = _context.Set<T>().Any(predicate);
            if (!exists)
            {
                Insert(entity);
                SaveChanges();
                return true;
            }
            return false;
        }

        public IList<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        protected void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException(e.InnerException.Message);
            }
        }
    }
}
