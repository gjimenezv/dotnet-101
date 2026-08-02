using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_101.Migrations
{
    /// <inheritdoc />
    public partial class AddListCustomerOrderCountProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE ListCostumerOrderCount
                    @MinOrders INT
                AS
                BEGIN
                SELECT c.Id AS Id, c.Name AS Name, COUNT(o.Id) as OrderCount
                FROM Customers c
                INNER JOIN Orders o on o.CustomerId = c.Id
                GROUP BY c.Id, c.Name
                HAVING COUNT(o.Id) >= @MinOrders
                ORDER BY OrderCount DESC
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE ListCostumerOrderCount");

        }
    }
}
