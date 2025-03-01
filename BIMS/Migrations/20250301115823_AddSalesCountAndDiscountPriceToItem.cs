using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BIMS.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesCountAndDiscountPriceToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPrice",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SalesCount",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SalesCount",
                table: "Items");
        }
    }
}
