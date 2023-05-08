using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_Assignment.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23d6586f-5bb3-422c-9e86-1c18afea70b4", null, "System Administrator", "SYSTEM ADMINISTRATOR" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23d6586f-5bb3-422c-9e86-1c18afea70b4");
        }
    }
}
