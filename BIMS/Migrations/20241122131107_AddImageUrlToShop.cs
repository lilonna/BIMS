using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BIMS.Migrations
{
    public partial class AddImageUrlToShop : Migration
    {
        // Up method for applying the migration
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Only add the ImageUrl column
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Shops",
                nullable: true);
        }

        // Down method for rolling back the migration
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the ImageUrl column to revert the changes
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Shops");
        }
    }
}
