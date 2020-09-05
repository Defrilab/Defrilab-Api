using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaiotBackend.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChangePasswords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangePasswords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gateway_id = table.Column<string>(nullable: true),
                    date_modified = table.Column<DateTime>(nullable: false),
                    owner = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    date_created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Help",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HelpName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateOfReporting = table.Column<string>(nullable: true),
                    ProblemLevel = table.Column<string>(nullable: true),
                    Project = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Help", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PopularName = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    FirstDateInOffice = table.Column<string>(nullable: true),
                    ProfilePhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    DateAndTime = table.Column<string>(nullable: true),
                    Sender = table.Column<string>(nullable: true),
                    IsMine = table.Column<bool>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Project = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Leader = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TimeSpan = table.Column<string>(nullable: true),
                    Sponsor = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPushNotificationsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrackTileValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_received = table.Column<DateTime>(nullable: false),
                    value = table.Column<int>(nullable: false),
                    timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackTileValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrackTileActuator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    TrackTileDeviceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackTileActuator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackTileActuator_Devices_TrackTileDeviceId",
                        column: x => x.TrackTileDeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrackTileSensor",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    valueId = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    TrackTileDeviceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackTileSensor", x => x.id);
                    table.ForeignKey(
                        name: "FK_TrackTileSensor_Devices_TrackTileDeviceId",
                        column: x => x.TrackTileDeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrackTileSensor_TrackTileValue_valueId",
                        column: x => x.valueId,
                        principalTable: "TrackTileValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrackTileActuator_TrackTileDeviceId",
                table: "TrackTileActuator",
                column: "TrackTileDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackTileSensor_TrackTileDeviceId",
                table: "TrackTileSensor",
                column: "TrackTileDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackTileSensor_valueId",
                table: "TrackTileSensor",
                column: "valueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangePasswords");

            migrationBuilder.DropTable(
                name: "Help");

            migrationBuilder.DropTable(
                name: "Leaders");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "TrackTileActuator");

            migrationBuilder.DropTable(
                name: "TrackTileSensor");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "TrackTileValue");
        }
    }
}
