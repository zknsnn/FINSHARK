using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RegistrarionRols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "551a669f-1e51-4355-8ab1-1555fe0fdeb5", "6cd7d1a0-d6bf-4657-aadd-d9ec08ff424c", "Admin", "ADMIN" },
                    { "8e28b4ce-8057-4503-8b38-6801ee58ce7c", "5390be1b-704d-4a43-bd4d-d1034c4df66e", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "551a669f-1e51-4355-8ab1-1555fe0fdeb5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e28b4ce-8057-4503-8b38-6801ee58ce7c");
        }
    }
}
