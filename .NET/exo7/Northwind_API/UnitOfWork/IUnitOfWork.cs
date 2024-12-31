using Northwind_API.DTO;
using Northwind_API.Repositories;

namespace Northwind_API.UnitOfWork
{
    public interface IUnitOfWork
    {
       OrderRepository OrderRepository { get; }
       EmployeeRepository EmployeeRepository { get; }
        Task SaveAsync();
    }
}
