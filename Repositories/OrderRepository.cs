using dotnet_101.Models;

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
    }
}