using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class item2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Item",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Item",
                newName: "Name");
        }
    }
}
