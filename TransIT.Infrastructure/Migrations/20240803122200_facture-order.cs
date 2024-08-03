using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class factureorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Factures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Factures_OrderId",
                table: "Factures",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Factures_Orders_OrderId",
                table: "Factures",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factures_Orders_OrderId",
                table: "Factures");

            migrationBuilder.DropIndex(
                name: "IX_Factures_OrderId",
                table: "Factures");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Factures");
        }
    }
}
