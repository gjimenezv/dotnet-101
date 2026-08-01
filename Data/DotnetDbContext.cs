using dotnet_101.Models;
using Microsoft.EntityFrameworkCore;

public class DotnetDbContext : DbContext
{
    public DotnetDbContext(DbContextOptions<DotnetDbContext> options) : base(options) {}

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(10,2);
        modelBuilder.Entity<OrderItem>().Property(p => p.UnitPrice).HasPrecision(10,2);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Manager)
            .WithMany(e => e.Reports)
            .HasForeignKey(e => e.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}