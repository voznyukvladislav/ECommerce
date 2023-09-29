using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceCMS_API.Migrations
{
    /// <inheritdoc />
    public partial class Order_ProductfieldTotalPriceadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Order_Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Order_Product");
        }
    }
}
