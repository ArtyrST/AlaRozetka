using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlaBackEnd.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SecondNameUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Users",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AllProducts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AllProducts");
        }
    }
}
