using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROG7311_POE_PART_2.Migrations
{
    /// <inheritdoc />
    public partial class SeedDemoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FullName",
                value: "Khano Sbandy");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Name", "ProductionDate" },
                values: new object[] { "Vegetables", "Chili Peppers", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FarmerId", "PasswordHash", "Role", "Username" },
                values: new object[] { null, "$2a$11$Q46hUfKMseJE7LaxstxlhulUYVhPLr8ozUG9v5vrs/tzOhyDVnFbK", "Employee", "employee" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "Role", "Username" },
                values: new object[] { "$2a$11$O8UzYcelj8d9dBGxrQKDYO5qJ.WP5GNeQPxcFhptyryLW0JbPavFa", "Farmer", "farmer" });
        }

        
        
    }
}
