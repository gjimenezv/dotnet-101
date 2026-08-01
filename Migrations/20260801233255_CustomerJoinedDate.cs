using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_101.Migrations
{
    /// <inheritdoc />
    public partial class CustomerJoinedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "JoinedDate",
                table: "Customers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JoinedDate",
                table: "Customers");
        }
    }
}
