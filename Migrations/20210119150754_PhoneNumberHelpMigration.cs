using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaiotBackend.Migrations
{
    public partial class PhoneNumberHelpMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Help",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Help");
        }
    }
}
