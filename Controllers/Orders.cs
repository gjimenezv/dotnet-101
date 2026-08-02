using Microsoft.AspNetCore.Mvc;
using dotnet_101.DTOs;
using dotnet_101.Services;

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
                return StatusCode(201,
                    new OrderDto(
                        order.Id,
                        order.Status,
                        order.OrderDate,
                        order.OrderItems.Select(
                            oi => new OrderItemDto(
                                oi.Id,
                                oi.Quantity,
                                oi.UnitPrice,
                                oi.ProductId,
                                oi.OrderId
                            )
                        ).ToList()));
            }
            catch (InvalidOperationException ex)
            {
                
                return Problem(detail: ex.Message, statusCode: 400);
            }
            
        }
    }
}