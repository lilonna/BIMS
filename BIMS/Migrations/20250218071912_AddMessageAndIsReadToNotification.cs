using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BIMS.Migrations
{
    /// <inheritdoc />
    public partial class AddMessageAndIsReadToNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Notifications",
                newName: "IsRead");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NotificationDate",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);



            migrationBuilder.DropColumn(
                name: "TempColumn",
                table: "Notifications");

         
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Notifications");

            migrationBuilder.AddColumn<bool>(
             name: "TempColumn",
             table: "Notifications",
             type: "bit",
             nullable: false,
             defaultValue: false);

            migrationBuilder.RenameColumn(
                name: "IsRead",
                table: "Notifications",
                newName: "IsActive");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "NotificationDate",
                table: "Notifications",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
