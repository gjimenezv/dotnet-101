using dotnet_101.Models;
using dotnet_101.DTOs;

namespace dotnet_101.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(int id);

        Task<List<CustomerOrderCountDto>> GetCustomerOrderCountAsync(int minOrders);

        Task<List<CustomerTotalSpentDto>> GetCustomerTotalSpenAsync();
    }
}