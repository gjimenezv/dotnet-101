 
namespace dotnet_101.DTOs
{
    public record OrderDto(
        int Id,
        string Status,
        DateTime OrderDate,
        List<OrderItemDto> Items
    );
}