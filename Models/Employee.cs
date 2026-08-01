namespace dotnet_101.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Title { get; set; } = null!;
        
        public int? ManagerId { get; set; }

        public DateTime HireDate { get; set; }


        public Employee? Manager { get; set; }

        public ICollection <Employee> Reports { get; set; } = new List<Employee>();
    }
}