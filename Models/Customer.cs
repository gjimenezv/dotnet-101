namespace dotnet_101.Models
{
    
    public class Customer
    {
        public int Id { get; set ;}

        public string Name { get; set; } = null!;

        public string City { get; set; } = null!;

        public DateOnly JoinedDate { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}