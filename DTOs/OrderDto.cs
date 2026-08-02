
using System.ComponentModel.DataAnnotations;

namespace dotnet_101.DTOs
{
    public record OrderDto(
        int Id,
        string Status,
        DateTime OrderDate,
        List<OrderItemDto> Items
    );

    public record CreateOrderRequest(
        [property: Range(1,int.MaxValue, ErrorMessage = "CustomerId not valid")]
        int CustomerId,
        [property: MinLength(1, ErrorMessage = "Items can't be empty")]
        List<CreateOrderItemRequest> Items
    );
}