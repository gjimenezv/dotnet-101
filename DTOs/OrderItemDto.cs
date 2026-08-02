namespace dotnet_101.DTOs
{
    public record OrderItemDto(
        int Id,
        int Quantity,
        decimal UnitPrice,
        int ProductId,
        int OrderId
        );
}