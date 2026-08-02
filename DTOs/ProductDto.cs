namespace dotnet_101.DTOs
{
    public record ProductDto (
        int id,
        string Name,
        decimal Price,
        string Category
    );
}