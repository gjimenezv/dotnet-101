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
                    @MIN_ORDERS INT
                AS
                BEGIN
                SELECT c.Id AS CustomerId, c.Name AS CustomerName, COUNT(o.Id) as OrdersCount
                FROM Customers c
                INNER JOIN Orders o on o.CustomerId = c.Id
                GROUP BY c.Id, c.Name
                HAVING COUNT(o.Id) >= @MIN_ORDERS
                ORDER BY OrdersCount DESC
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
