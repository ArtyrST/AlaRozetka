using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AlaBackEnd.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProductCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monitores_Categories_CategoryId",
                table: "Monitores");

            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Monitores",
                table: "Monitores");

            migrationBuilder.RenameTable(
                name: "Monitores",
                newName: "AllProducts");

            migrationBuilder.RenameIndex(
                name: "IX_Monitores_CategoryId",
                table: "AllProducts",
                newName: "IX_AllProducts_CategoryId");

            migrationBuilder.AlterColumn<float>(
                name: "Resolution",
                table: "AllProducts",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AllProducts",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "MatrixType",
                table: "AllProducts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "AllProducts",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Cpu",
                table: "AllProducts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "AllProducts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DdrSeries",
                table: "AllProducts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AllProducts",
                type: "character varying(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Disk",
                table: "AllProducts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Memory",
                table: "AllProducts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductMonitorEntity_Brand",
                table: "AllProducts",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ram",
                table: "AllProducts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllProducts",
                table: "AllProducts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    CartId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_AllProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "AllProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CartId",
                table: "OrderItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AllProducts_Categories_CategoryId",
                table: "AllProducts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllProducts_Categories_CategoryId",
                table: "AllProducts");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllProducts",
                table: "AllProducts");

            migrationBuilder.DropColumn(
                name: "Cpu",
                table: "AllProducts");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "AllProducts");

            migrationBuilder.DropColumn(
                name: "DdrSeries",
                table: "AllProducts");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AllProducts");

            migrationBuilder.DropColumn(
                name: "Disk",
                table: "AllProducts");

            migrationBuilder.DropColumn(
                name: "Memory",
                table: "AllProducts");

            migrationBuilder.DropColumn(
                name: "ProductMonitorEntity_Brand",
                table: "AllProducts");

            migrationBuilder.DropColumn(
                name: "Ram",
                table: "AllProducts");

            migrationBuilder.RenameTable(
                name: "AllProducts",
                newName: "Monitores");

            migrationBuilder.RenameIndex(
                name: "IX_AllProducts_CategoryId",
                table: "Monitores",
                newName: "IX_Monitores_CategoryId");

            migrationBuilder.AlterColumn<float>(
                name: "Resolution",
                table: "Monitores",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Monitores",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "MatrixType",
                table: "Monitores",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Monitores",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Monitores",
                table: "Monitores",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: true),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    Cpu = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DdrSeries = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Memory = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Ram = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laptops_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_CategoryId",
                table: "Laptops",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitores_Categories_CategoryId",
                table: "Monitores",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
