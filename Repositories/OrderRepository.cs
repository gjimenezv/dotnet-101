using dotnet_101.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_101.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DotnetDbContext _context;

        public OrderRepository(DotnetDbContext context) => _context = context;

        public async Task<Order> CreateAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public Task<Order?> GetByIdAsync(int id)
        {
            return _context.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            await _context.SaveChangesAsync();
            return order;
        }
    }
}