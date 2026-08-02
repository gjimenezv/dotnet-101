using dotnet_101.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_101.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DotnetDbContext _contex;

        public ProductRepository(DotnetDbContext contex)
        {
            _contex = contex;
        }

        public Task<List<Product>> GetAllAsync()
        {
            return _contex.Products.Include(p => p.Category).ToListAsync();
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            return _contex.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<List<Product>> GetByIdsAsync(List<int> ids)
        {
            return _contex.Products.Include(p => p.Category).Where(p => ids.Contains(p.Id)).ToListAsync();
        }
    }
}