using dotnet_101.DTOs;
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

        public Task<List<Product>> ListByIdsAsync(List<int> ids)
        {
            return _contex.Products.Include(p => p.Category).Where(p => ids.Contains(p.Id)).ToListAsync();
        }

        public Task<List<TopProductsSoldByCategoryDto>> TopProductsSoldByCategoryAsync(int topN, int? categoryId)
        {
            return _contex.Database.SqlQueryRaw<TopProductsSoldByCategoryDto>(@"
                WITH TotalsByProduct AS (
                SELECT 
                    p.Id as ProductId,
                    p.CategoryId as CategoryId,
                    SUM(oi.Quantity) as TotalUnitsSold,
                    SUM(oi.Quantity * oi.UnitPrice ) as TotalRevenue,
                    RANK() OVER (PARTITION BY p.CategoryId  ORDER BY SUM(oi.Quantity) DESC) as Rank
                FROM Products p
                INNER JOIN OrderItems oi on oi.ProductId = p.Id 
                INNER JOIN Orders o on o.Id   = oi.OrderId 
                WHERE o.Status = 'Shipped'
                GROUP BY p.Id, p.CategoryId 
                )
                SELECT
                    tp.ProductId,
                    p.Name as ProductName,
                    c.Id as CategoryId,
                    c.Name as CategoryName,
                    tp.TotalUnitsSold,
                    tp.TotalRevenue,
                    tp.Rank
                FROM TotalsByProduct tp
                INNER JOIN Products p on tp.ProductId = p.Id 
                INNER JOIN Categories c on p.CategoryId   = c.Id
                WHERE tp.Rank <= {0}
                    AND ({1} IS NULL OR tp.CategoryId = {1})
            ",topN,categoryId).ToListAsync();
        }
    }
}