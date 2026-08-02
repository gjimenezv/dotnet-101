using dotnet_101.DTOs;
using dotnet_101.Models;

namespace dotnet_101.Extensions
{
    public static class OrderExtensions
    {
        public static OrderDto ToDto(this Order order) => new OrderDto(
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
                        ).ToList());
    }
}