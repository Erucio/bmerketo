using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_Assignment.Migrations
{
    /// <inheritdoc />
    public partial class SeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23d6586f-5bb3-422c-9e86-1c18afea70b4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df613cdd-5366-4ac1-b081-05d4ffb5f374", null, "System Administrator", "SYSTEM ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e7378b8b-0b7b-4265-b490-b708a092b484", 0, null, "5cb1b43d-3bd8-4ce3-a942-849e17e34898", null, false, "System", null, "Administrator", false, null, null, null, "AQAAAAIAAYagAAAAENNcsV/tgf5DTERFXHHKbDq0+FhpUfwinu4Fqyt5z2vQc1fR5vv/16LdEccFWgwavA==", null, false, "be905df8-2cc4-4ff5-ad9b-ce3a22a41c03", false, "administrator" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df613cdd-5366-4ac1-b081-05d4ffb5f374");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7378b8b-0b7b-4265-b490-b708a092b484");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23d6586f-5bb3-422c-9e86-1c18afea70b4", null, "System Administrator", "SYSTEM ADMINISTRATOR" });
        }
    }
}
