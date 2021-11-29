using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaiotBackend.Migrations
{
    public partial class LatestDeviceInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "X_acc",
                table: "DeviceMessage",
                newName: "x_acc");

            migrationBuilder.RenameColumn(
                name: "LDR",
                table: "DeviceMessage",
                newName: "Ldr");

            migrationBuilder.AlterColumn<int>(
                name: "Temp",
                table: "DeviceMessage",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "DeviceMessage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "deviceTypeId",
                table: "DeviceMessage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "DeviceMessage");

            migrationBuilder.DropColumn(
                name: "deviceTypeId",
                table: "DeviceMessage");

            migrationBuilder.RenameColumn(
                name: "x_acc",
                table: "DeviceMessage",
                newName: "X_acc");

            migrationBuilder.RenameColumn(
                name: "Ldr",
                table: "DeviceMessage",
                newName: "LDR");

            migrationBuilder.AlterColumn<short>(
                name: "Temp",
                table: "DeviceMessage",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
