using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlaBackEnd.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProductFix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBackEntity_AllProducts_ProductId",
                table: "FeedBackEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBackEntity_Users_UserId",
                table: "FeedBackEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedBackEntity",
                table: "FeedBackEntity");

            migrationBuilder.RenameTable(
                name: "FeedBackEntity",
                newName: "Feedbacks");

            migrationBuilder.RenameIndex(
                name: "IX_FeedBackEntity_UserId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FeedBackEntity_ProductId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_AllProducts_ProductId",
                table: "Feedbacks",
                column: "ProductId",
                principalTable: "AllProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Users_UserId",
                table: "Feedbacks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_AllProducts_ProductId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Users_UserId",
                table: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.RenameTable(
                name: "Feedbacks",
                newName: "FeedBackEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_UserId",
                table: "FeedBackEntity",
                newName: "IX_FeedBackEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_ProductId",
                table: "FeedBackEntity",
                newName: "IX_FeedBackEntity_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedBackEntity",
                table: "FeedBackEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBackEntity_AllProducts_ProductId",
                table: "FeedBackEntity",
                column: "ProductId",
                principalTable: "AllProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBackEntity_Users_UserId",
                table: "FeedBackEntity",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
