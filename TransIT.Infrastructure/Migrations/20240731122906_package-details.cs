using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class packagedetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimensions",
                table: "Packages");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Packages");

            migrationBuilder.AddColumn<decimal>(
                name: "Dimensions",
                table: "Packages",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
