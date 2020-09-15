using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaiotBackend.Migrations
{
    public partial class SettingUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPushNotificationsEnabled",
                table: "Settings");

            migrationBuilder.AddColumn<bool>(
                name: "IsAppNotificationsOn",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMarkettingNotificationsOn",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNightModeOn",
                table: "Settings",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAppNotificationsOn",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "IsMarkettingNotificationsOn",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "IsNightModeOn",
                table: "Settings");

            migrationBuilder.AddColumn<bool>(
                name: "IsPushNotificationsEnabled",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
