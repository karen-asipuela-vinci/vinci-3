using Microsoft.EntityFrameworkCore;
using Northwind_API.Entities;
using System.Linq.Expressions;

namespace Northwind_API.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly List<Order> _orders;

        public OrderRepository()
        {
            _orders = new List<Order>();
            _orders.Add(new Order
            {
                OrderId = 1,
                CustomerId = "ALFKI",
                EmployeeId = 1,
                OrderDate = new DateTime(2021, 1, 1),
                RequiredDate = new DateTime(2021, 1, 10),
                ShippedDate = new DateTime(2021, 1, 5),
                ShipVia = 1,
                Freight = 12.34m,
                ShipName = "John Doe",
                ShipAddress = "123 Elm St",
                ShipCity = "Springfield",
                ShipRegion = "IL",
                ShipPostalCode = "62701",
                ShipCountry = "USA"
            });
        }

        public Task DeleteAsync(Order entity)
        {
            _orders.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<IList<Order>> GetAllAsync()
        {
            return Task.FromResult((IList<Order>)_orders);
        }

        public Task<Order> GetByIdAsync(int id)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == id);
            return Task.FromResult(order);
        }

        public Task InsertAsync(Order entity)
        {
            _orders.Add(entity);
            return Task.CompletedTask;
        }

        public Task<IList<Order>> SearchForAsync(Expression<Func<Order, bool>> predicate)
        {
            var result = _orders.AsQueryable().Where(predicate).ToList();
            return Task.FromResult((IList<Order>)result);
        }
    }
}
