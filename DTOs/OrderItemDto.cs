using System.ComponentModel.DataAnnotations;

namespace dotnet_101.DTOs
{
    public record OrderItemDto(
        int Id,
        int Quantity,
        decimal UnitPrice,
        int ProductId,
        int OrderId
    );

    public record CreateOrderItemRequest(
        [property: Range(1,int.MaxValue, ErrorMessage = "Quantity debe ser mayor a 0")]
        int Quantity,
        int ProductId
    );

}