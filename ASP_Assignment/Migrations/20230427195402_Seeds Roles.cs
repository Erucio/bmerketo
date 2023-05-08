using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_Assignment.Migrations
{
    /// <inheritdoc />
    public partial class SeedsRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "330f2597-9486-4240-831a-7c4737768f2c", null, "System Administrator", "SYSTEM ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "23ac1db3-0055-44c3-bc8b-06829b548b45", 0, null, "ca42f50c-d4f2-440f-9239-949ec0052eb1", "administrator@domain.com", false, "", null, "", false, null, null, null, "AQAAAAIAAYagAAAAEJg7wPuvJFE/kcmAXHPe1jtIDgzGWy0gIN77q+7+szL/+SUL1z4jBDXuQUDNA/6Scg==", null, false, "fff2626d-0f26-4cea-9a22-3c4803bd1866", false, "administrator@domain.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "330f2597-9486-4240-831a-7c4737768f2c", "23ac1db3-0055-44c3-bc8b-06829b548b45" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "330f2597-9486-4240-831a-7c4737768f2c", "23ac1db3-0055-44c3-bc8b-06829b548b45" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "330f2597-9486-4240-831a-7c4737768f2c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23ac1db3-0055-44c3-bc8b-06829b548b45");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df613cdd-5366-4ac1-b081-05d4ffb5f374", null, "System Administrator", "SYSTEM ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e7378b8b-0b7b-4265-b490-b708a092b484", 0, null, "5cb1b43d-3bd8-4ce3-a942-849e17e34898", null, false, "System", null, "Administrator", false, null, null, null, "AQAAAAIAAYagAAAAENNcsV/tgf5DTERFXHHKbDq0+FhpUfwinu4Fqyt5z2vQc1fR5vv/16LdEccFWgwavA==", null, false, "be905df8-2cc4-4ff5-ad9b-ce3a22a41c03", false, "administrator" });
        }
    }
}
