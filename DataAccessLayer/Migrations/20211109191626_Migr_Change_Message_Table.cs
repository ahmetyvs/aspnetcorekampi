using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Migr_Change_Message_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderID",
                table: "Messages",
                newName: "Sender");

            migrationBuilder.RenameColumn(
                name: "ReceiverID",
                table: "Messages",
                newName: "Receiver");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sender",
                table: "Messages",
                newName: "SenderID");

            migrationBuilder.RenameColumn(
                name: "Receiver",
                table: "Messages",
                newName: "ReceiverID");
        }
    }
}
