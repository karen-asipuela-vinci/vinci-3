using Northwind_API.DTO;
using Northwind_API.Entities;
using Northwind_API.Repositories;

namespace Northwind_API.UnitOfWork
{
    public class UnitOfWorkMem : IUnitOfWork
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly OrderRepository _orderRepository;

        public UnitOfWorkMem()
        {
            _employeeRepository = new();
            _orderRepository = new();
        }

        public EmployeeRepository EmployeeRepository => _employeeRepository;
        public OrderRepository  OrderRepository => _orderRepository;

        public Task SaveAsync()
        {
            // Implémentation de la méthode SaveAsync
            return Task.CompletedTask;
        }
    }
}
