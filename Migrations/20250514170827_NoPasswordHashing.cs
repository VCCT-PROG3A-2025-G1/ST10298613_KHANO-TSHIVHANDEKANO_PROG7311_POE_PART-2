using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROG7311_POE_PART_2.Migrations
{
    /// <inheritdoc />
    public partial class NoPasswordHashing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "Password");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "password");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$7dINkNWDlEYo0LTxQuPf4OeO0Z0dOTm0rNyO3nHHHPaRA3S6Ms6bi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$7dINkNWDlEYo0LTxQuPf4OeO0Z0dOTm0rNyO3nHHHPaRA3S6Ms6bi");
        }
    }
}
