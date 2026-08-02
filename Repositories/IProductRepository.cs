using dotnet_101.Models;

namespace dotnet_101.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(int id);

        Task<List<Product>> GetByIdsAsync(List<int> ids);
    }
}