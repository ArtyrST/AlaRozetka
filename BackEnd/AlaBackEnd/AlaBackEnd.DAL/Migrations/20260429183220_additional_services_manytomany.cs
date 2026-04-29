using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlaBackEnd.DAL.Migrations
{
    /// <inheritdoc />
    public partial class additional_services_manytomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalServices_AllProducts_ProductId",
                table: "AdditionalServices");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalServices_ProductId",
                table: "AdditionalServices");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "AdditionalServices");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "AdditionalServices",
                newName: "Price");

            migrationBuilder.CreateTable(
                name: "AdditionalServicesWithProducts",
                columns: table => new
                {
                    AdditionalServicesId = table.Column<int>(type: "integer", nullable: false),
                    ProductsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalServicesWithProducts", x => new { x.AdditionalServicesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_AdditionalServicesWithProducts_AdditionalServices_Additiona~",
                        column: x => x.AdditionalServicesId,
                        principalTable: "AdditionalServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalServicesWithProducts_AllProducts_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "AllProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalServicesWithProducts_ProductsId",
                table: "AdditionalServicesWithProducts",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalServicesWithProducts");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "AdditionalServices",
                newName: "price");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "AdditionalServices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalServices_ProductId",
                table: "AdditionalServices",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalServices_AllProducts_ProductId",
                table: "AdditionalServices",
                column: "ProductId",
                principalTable: "AllProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
