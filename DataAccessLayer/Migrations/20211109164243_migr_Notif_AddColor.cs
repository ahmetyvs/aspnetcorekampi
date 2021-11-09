using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class migr_Notif_AddColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotificationnType",
                table: "Notifications",
                newName: "NotificationType");

            migrationBuilder.AddColumn<string>(
                name: "NotificationColor",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificationColor",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "NotificationType",
                table: "Notifications",
                newName: "NotificationnType");
        }
    }
}
