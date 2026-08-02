using dotnet_101.Models;

namespace dotnet_101.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);
    }
}