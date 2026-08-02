namespace dotnet_101.DTOs
{
    public record CustomerDto(int Id, string Name, string City, DateOnly JoinedDate, List<OrderDto> orders);

    public record CustomerOrderCountDto(int Id, string Name, int OrderCount);

    public record CustomerTotalSpentDto(int Id, string Name, decimal TotalSpent);

}