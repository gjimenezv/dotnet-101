using dotnet_101.DTOs;
using dotnet_101.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_101.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CustomersController: ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository) => _customerRepository = customerRepository;

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetById(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer is null) return NotFound();

            return new CustomerDto(
                customer.Id,
                customer.Name,
                customer.City,
                customer.JoinedDate,
                customer.Orders.Select(o => 
                    new OrderDto(
                        o.Id,
                        o.Status,
                        o.OrderDate,
                        o.OrderItems.Select(oi => 
                            new OrderItemDto(
                                oi.Id,
                                oi.Quantity,
                                oi.UnitPrice,
                                oi.ProductId,
                                oi.OrderId
                            )
                        ).ToList()
                    )
                ).ToList()
            );
        }

        [HttpGet("top-spenders")]
        public async Task<ActionResult<List<CustomerOrderCountDto>>> TopSpenders(int minOrders)
        {
            var result = await _customerRepository.GetCustomerOrderCountAsync(minOrders);

            return Ok(result);
        }

        [HttpGet("above-average")]
        public async Task<ActionResult<List<CustomerOrderCountDto>>> AboveAverage()
        {
            var result = await _customerRepository.GetCustomerTotalSpenAsync();

            return Ok(result);
        }
    }
}