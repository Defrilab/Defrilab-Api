using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaiotBackend.Migrations
{
    public partial class LatestDeviceManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ACC_X",
                table: "DeviceMessage");

            migrationBuilder.DropColumn(
                name: "ACC_Y",
                table: "DeviceMessage");

            migrationBuilder.DropColumn(
                name: "ACC_Z",
                table: "DeviceMessage");

            migrationBuilder.DropColumn(
                name: "GeophoneAnalogValue",
                table: "DeviceMessage");

            migrationBuilder.AddColumn<int>(
                name: "Geophone_analog_value",
                table: "DeviceMessage",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "X_acc",
                table: "DeviceMessage",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Y_acc",
                table: "DeviceMessage",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Z_acc",
                table: "DeviceMessage",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Geophone_analog_value",
                table: "DeviceMessage");

            migrationBuilder.DropColumn(
                name: "X_acc",
                table: "DeviceMessage");

            migrationBuilder.DropColumn(
                name: "Y_acc",
                table: "DeviceMessage");

            migrationBuilder.DropColumn(
                name: "Z_acc",
                table: "DeviceMessage");

            migrationBuilder.AddColumn<int>(
                name: "ACC_X",
                table: "DeviceMessage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ACC_Y",
                table: "DeviceMessage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ACC_Z",
                table: "DeviceMessage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GeophoneAnalogValue",
                table: "DeviceMessage",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
