using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BIMS.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOwnershipTypeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the foreign key constraint
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_OwnershipTypes_OwnershipTypeId",
                table: "Owners");

            // Drop the index on OwnershipTypeId
            migrationBuilder.DropIndex(
                name: "IX_Owners_OwnershipTypeId",
                table: "Owners");

            // Drop the column
            migrationBuilder.DropColumn(
                name: "OwnershipTypeId",
                table: "Owners");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Recreate the column
            migrationBuilder.AddColumn<int>(
                name: "OwnershipTypeId",
                table: "Owners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Recreate the index
            migrationBuilder.CreateIndex(
                name: "IX_Owners_OwnershipTypeId",
                table: "Owners",
                column: "OwnershipTypeId");

            // Recreate the foreign key constraint
            migrationBuilder.AddForeignKey(
                name: "FK_Owners_OwnershipTypes_OwnershipTypeId",
                table: "Owners",
                column: "OwnershipTypeId",
                principalTable: "OwnershipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
