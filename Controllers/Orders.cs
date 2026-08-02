using Microsoft.AspNetCore.Mvc;
using dotnet_101.DTOs;
using dotnet_101.Services;
using dotnet_101.Models;
using dotnet_101.Extensions;

namespace dotnet_101.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService) => _orderService = orderService;


        [HttpPost()]
        public async Task<ActionResult<OrderDto>> PlaceOrder(CreateOrderRequest request)
        {
            try
            {
                var order = await _orderService.PlaceOrderAsync(request);
                return StatusCode(201,order.ToDto());
            }
            catch (KeyNotFoundException ex)
            {
                
                return Problem(detail: ex.Message, statusCode: 400);
            }
            
        }

        [HttpPatch("{id}/cancel")]
        public async Task<ActionResult<OrderDto>> CancelOrderAsync(int id)
        {
            try
            {
                var order = await _orderService.CancelOrderAsync(id);
                return Ok(order.ToDto());
            }
            catch (KeyNotFoundException ex)
            {
                
                return Problem(detail: ex.Message, statusCode: 404);
            }
            catch (InvalidOperationException ex)
            {
                return Problem(detail: ex.Message, statusCode: 409);
            }
        }
    }
}