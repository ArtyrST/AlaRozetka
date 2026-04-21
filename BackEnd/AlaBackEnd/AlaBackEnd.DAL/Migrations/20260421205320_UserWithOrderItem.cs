using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlaBackEnd.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserWithOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RieltorId",
                table: "OrderItems",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "OrderItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "AllProducts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_UserId",
                table: "OrderItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AllProducts_OrderId",
                table: "AllProducts",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllProducts_OrderItems_OrderId",
                table: "AllProducts",
                column: "OrderId",
                principalTable: "OrderItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Users_UserId",
                table: "OrderItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllProducts_OrderItems_OrderId",
                table: "AllProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Users_UserId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_UserId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_AllProducts_OrderId",
                table: "AllProducts");

            migrationBuilder.DropColumn(
                name: "RieltorId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "AllProducts");
        }
    }
}
