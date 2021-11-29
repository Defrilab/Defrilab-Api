using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaiotBackend.Migrations
{
    public partial class RtgsmsDeviceMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceMessage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lat = table.Column<int>(nullable: false),
                    Long = table.Column<int>(nullable: false),
                    GeophoneAnalogValue = table.Column<int>(nullable: false),
                    LDR = table.Column<int>(nullable: false),
                    ACC_X = table.Column<int>(nullable: false),
                    ACC_Y = table.Column<int>(nullable: false),
                    ACC_Z = table.Column<int>(nullable: false),
                    Temp = table.Column<short>(nullable: false),
                    Hum = table.Column<int>(nullable: false),
                    Flags = table.Column<int>(nullable: false),
                    Device = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceMessage", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceMessage");
        }
    }
}
