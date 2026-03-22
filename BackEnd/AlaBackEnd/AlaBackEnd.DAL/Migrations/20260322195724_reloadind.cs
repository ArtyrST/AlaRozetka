using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlaBackEnd.DAL.Migrations
{
    /// <inheritdoc />
    public partial class reloadind : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "AllProducts");

            migrationBuilder.DropColumn(
                name: "Cpu",
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
                name: "MatrixType",
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

            migrationBuilder.DropColumn(
                name: "Resolution",
                table: "AllProducts");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "AllProducts",
                newName: "Country");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGuest",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRieltor",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeFrom",
                table: "OrderItems",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeTo",
                table: "OrderItems",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsGuest",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsRieltor",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TimeFrom",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "TimeTo",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "AllProducts",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "AllProducts",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpu",
                table: "AllProducts",
                type: "text",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "MatrixType",
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

            migrationBuilder.AddColumn<float>(
                name: "Resolution",
                table: "AllProducts",
                type: "real",
                nullable: true);
        }
    }
}
