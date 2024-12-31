using Microsoft.EntityFrameworkCore;
using Northwind_API.Entities;
using System.Linq.Expressions;

namespace Northwind_API.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly List<Employee> _employees;
        private int _currentId = 1;

        public EmployeeRepository()
        {
            _employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeId = _currentId++,
                    FirstName = "John",
                    LastName = "Doe",
                    Title = "Software Developer",
                    BirthDate = new DateTime(1990, 1, 1),
                    HireDate = new DateTime(2010, 1, 1)
                }
            };
        }

        public Task InsertAsync(Employee entity)
        {
            if (_employees.Any(e => e.FirstName == entity.FirstName && e.LastName == entity.LastName))
            {
                throw new InvalidOperationException("Employee already exists.");
            }

            entity.EmployeeId = _currentId++;
            _employees.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Employee entity)
        {
            _employees.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<IList<Employee>> GetAllAsync()
        {
            return Task.FromResult((IList<Employee>)_employees);
        }

        public Task<Employee?> GetByIdAsync(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.EmployeeId == id);
            return Task.FromResult(employee);
        }

        public Task<IList<Employee>> SearchForAsync(Expression<Func<Employee, bool>> predicate)
        {
            var query = _employees.AsQueryable().Where(predicate);
            return Task.FromResult((IList<Employee>)query.ToList());
        }

        public Task UpdateAsync(Employee entity)
        {
            var existingEmployee = _employees.FirstOrDefault(e => e.EmployeeId == entity.EmployeeId);
            if (existingEmployee == null)
            {
                throw new InvalidOperationException("Employee not found.");
            }

            existingEmployee.FirstName = entity.FirstName;
            existingEmployee.LastName = entity.LastName;
            existingEmployee.Title = entity.Title;
            existingEmployee.BirthDate = entity.BirthDate;
            existingEmployee.HireDate = entity.HireDate;

            return Task.CompletedTask;
        }
    }
}
