namespace dotnet_101.DTOs
{
    public record ProductDto (
        int id,
        string Name,
        decimal Price,
        string Category
    );

    public record TopProductsSoldByCategoryDto (
        int ProductId,
        string ProductName,
        int CategoryId,
        string CategoryName,
        int TotalUnitsSold,
        decimal TotalRevenue,
        long Rank
    );
}