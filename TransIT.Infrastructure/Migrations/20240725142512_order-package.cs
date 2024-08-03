using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class orderpackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_OrderId",
                table: "Packages",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Orders_OrderId",
                table: "Packages",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Orders_OrderId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_OrderId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Packages");
        }
    }
}
