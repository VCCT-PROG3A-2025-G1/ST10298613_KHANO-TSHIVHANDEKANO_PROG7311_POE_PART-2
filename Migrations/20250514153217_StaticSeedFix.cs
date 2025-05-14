using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROG7311_POE_PART_2.Migrations
{
    /// <inheritdoc />
    public partial class StaticSeedFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FullName",
                value: "Khano");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "ProductionDate" },
                values: new object[] { "Chilli", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "ProductionDate" },
                values: new object[] { "Butternut", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FarmerId", "PasswordHash", "Role", "Username" },
                values: new object[] { null, "$2a$11$7dINkNWDlEYo0LTxQuPf4OeO0Z0dOTm0rNyO3nHHHPaRA3S6Ms6bi", "Employee", "employee" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "Role", "Username" },
                values: new object[] { "$2a$11$7dINkNWDlEYo0LTxQuPf4OeO0Z0dOTm0rNyO3nHHHPaRA3S6Ms6bi", "Farmer", "farmer" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FullName",
                value: "Sipho Nkosi");

            migrationBuilder.InsertData(
                table: "Farmers",
                columns: new[] { "Id", "FullName", "Location" },
                values: new object[] { 2, "Anna Molefe", "KwaZulu-Natal" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "ProductionDate" },
                values: new object[] { "Chillies", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "ProductionDate" },
                values: new object[] { "Green Beans", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FarmerId", "PasswordHash", "Role", "Username" },
                values: new object[] { 1, "hashedpassword1", "Farmer", "farmer1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "Role", "Username" },
                values: new object[] { "hashedpassword2", "Employee", "employee1" });
        }
    }
}
