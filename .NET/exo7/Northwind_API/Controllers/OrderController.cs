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
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            var orders = await _unitOfWork.OrderRepository.GetAllAsync();
            var orderDTOs = orders.Select(o => new OrderDTO
            {
                OrderId = o.OrderId,
                CustomerId = o.CustomerId,
                ShippedDate = o.ShippedDate
            });
            return Ok(orderDTOs);
        }

        // GET: api/Order/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            var orderDTO = new OrderDTO
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                ShippedDate = order.ShippedDate
            };
            return Ok(orderDTO);
        }

        // POST: api/Order
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> CreateOrder(OrderDTO orderDTO)
        {
            var order = new Order
            {
                CustomerId = orderDTO.CustomerId,
                OrderDate = orderDTO.OrderDate,
                ShippedDate = orderDTO.ShippedDate
            };

            await _unitOfWork.OrderRepository.InsertAsync(order);
            await _unitOfWork.SaveAsync();

            orderDTO.OrderId = order.OrderId;
            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, orderDTO);
        }

        // PUT: api/Order/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderDTO updatedOrderDTO)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            order.CustomerId = updatedOrderDTO.CustomerId;
            order.OrderDate = updatedOrderDTO.OrderDate;
            order.ShippedDate = updatedOrderDTO.ShippedDate;

            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        // DELETE: api/Order/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            await _unitOfWork.OrderRepository.DeleteAsync(order);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
