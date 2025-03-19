using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BIMS.Migrations
{
    /// <inheritdoc />
    public partial class AddTransactionRefAndBankNameAndWebhookResponse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "Owners",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TransactionRef",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankName",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "TransactionRef",
                table: "Orders");
        }
    }
}
