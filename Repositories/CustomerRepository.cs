using dotnet_101.DTOs;
using dotnet_101.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_101.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DotnetDbContext _context;

        public CustomerRepository(DotnetDbContext context) => _context = context;


        public Task<Customer?> GetByIdAsync(int id)
        {
            return _context.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderItems)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<CustomerOrderCountDto>> GetCustomerOrderCountAsync(int minOrders)
        {
            return _context.Customers
            .Where(c => c.Orders.Count(o => o.Status == "Shipped") >= minOrders)
            .Select(
                c => new CustomerOrderCountDto(
                    c.Id,
                    c.Name,
                    c.Orders.Count(o => o.Status == "Shipped")))
            .ToListAsync();
        }

        public async Task<List<CustomerTotalSpentDto>> GetCustomerTotalSpenAsync()
        {
            var average = await _context.Customers.Select(c => 
                c.Orders.Where(o => o.Status == "Shipped")
                .SelectMany(o => o.OrderItems)
                .Sum(oi => oi.Quantity * oi.UnitPrice)
            ).AverageAsync();

            return await _context.Customers
            .Where(c => 
                c.Orders.Where(o => o.Status == "Shipped")
                .SelectMany(o => o.OrderItems)
                .Sum(oi => oi.Quantity * oi.UnitPrice) > average
            )
            .Select(c => new CustomerTotalSpentDto(c.Id, c.Name, c.Orders.Where(o => o.Status == "Shipped")
                .SelectMany(o => o.OrderItems)
                .Sum(oi => oi.Quantity * oi.UnitPrice)))
            .ToListAsync();
        }
    }
}