using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b1aebe4-7f3b-4714-a581-92577200b458");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ac3c4d4-7020-4958-8d78-61063b9508a3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b1aebe4-7f3b-4714-a581-92577200b458", "fd6eaade-a5af-4247-a3bc-3778c42a1311", "User", "USER" },
                    { "7ac3c4d4-7020-4958-8d78-61063b9508a3", "1d254fb1-b86b-46c0-8756-fff7f190c89e", "Admin", "ADMIN" }
                });
        }
    }
}
