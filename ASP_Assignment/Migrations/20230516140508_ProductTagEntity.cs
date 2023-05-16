using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_Assignment.Migrations
{
    /// <inheritdoc />
    public partial class ProductTagEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTagEntity_Products_ArticleNumber",
                table: "ProductTagEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTagEntity_Tags_TagId",
                table: "ProductTagEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTagEntity",
                table: "ProductTagEntity");

            migrationBuilder.RenameTable(
                name: "ProductTagEntity",
                newName: "ProductTags");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTagEntity_TagId",
                table: "ProductTags",
                newName: "IX_ProductTags_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTags",
                table: "ProductTags",
                columns: new[] { "ArticleNumber", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Products_ArticleNumber",
                table: "ProductTags",
                column: "ArticleNumber",
                principalTable: "Products",
                principalColumn: "ArticleNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Tags_TagId",
                table: "ProductTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Products_ArticleNumber",
                table: "ProductTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Tags_TagId",
                table: "ProductTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTags",
                table: "ProductTags");

            migrationBuilder.RenameTable(
                name: "ProductTags",
                newName: "ProductTagEntity");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTags_TagId",
                table: "ProductTagEntity",
                newName: "IX_ProductTagEntity_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTagEntity",
                table: "ProductTagEntity",
                columns: new[] { "ArticleNumber", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTagEntity_Products_ArticleNumber",
                table: "ProductTagEntity",
                column: "ArticleNumber",
                principalTable: "Products",
                principalColumn: "ArticleNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTagEntity_Tags_TagId",
                table: "ProductTagEntity",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
