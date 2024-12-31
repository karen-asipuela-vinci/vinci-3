using System.Linq.Expressions;

namespace Northwind_API.Repositories
{
    public interface IRepository<T>
    {
        Task InsertAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IList<T>> SearchForAsync(Expression<Func<T, bool>> predicate);
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

    }
}
