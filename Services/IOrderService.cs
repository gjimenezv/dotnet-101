using dotnet_101.DTOs;
using dotnet_101.Models;

namespace dotnet_101.Services
{
    public interface IOrderService
    {
        Task<Order> PlaceOrderAsync (CreateOrderRequest request);
        Task<Order> CancelOrderAsync (int id);
    }
}