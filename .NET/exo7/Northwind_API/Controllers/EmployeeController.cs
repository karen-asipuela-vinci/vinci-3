using Microsoft.AspNetCore.Mvc;
using Northwind_API.DTO;
using Northwind_API.Entities;
using Northwind_API.Repositories;
using Northwind_API.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var employees = await _unitOfWork.EmployeeRepository.GetAllAsync();
            var employeeDTOs = employees.Select(e => new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                LastName = e.LastName,
                FirstName = e.FirstName
            });
            return Ok(employeeDTOs);
        }

        // GET: api/Employee/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            var employeeDTO = new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                LastName = employee.LastName,
                FirstName = employee.FirstName
            };
            return Ok(employeeDTO);
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> CreateEmployee(EmployeeDTO employeeDTO)
        {
            var employee = new Employee
            {
                LastName = employeeDTO.LastName,
                FirstName = employeeDTO.FirstName
            };

            await _unitOfWork.EmployeeRepository.InsertAsync(employee);
            await _unitOfWork.SaveAsync();

            employeeDTO.EmployeeId = employee.EmployeeId;
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employeeDTO);
        }

        // PUT: api/Employee/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeDTO updatedEmployeeDTO)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            employee.LastName = updatedEmployeeDTO.LastName;
            employee.FirstName = updatedEmployeeDTO.FirstName;

            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        // DELETE: api/Employee/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            await _unitOfWork.EmployeeRepository.DeleteAsync(employee);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
