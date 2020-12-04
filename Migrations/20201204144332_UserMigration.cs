using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaiotBackend.Migrations
{
    public partial class UserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CMappEmployees");

            migrationBuilder.DropTable(
                name: "CMappFertilizers");

            migrationBuilder.DropTable(
                name: "CMappHerbicides");

            migrationBuilder.DropTable(
                name: "CmappMessages");

            migrationBuilder.DropTable(
                name: "CMappSeedlings");

            migrationBuilder.DropTable(
                name: "CmappTasks");

            migrationBuilder.DropTable(
                name: "TrackTileActuator");

            migrationBuilder.DropTable(
                name: "TrackTileSensor");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "TrackTileValue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CMappEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMappEmployees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CMappFertilizers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentQnt = table.Column<int>(type: "int", nullable: false),
                    EstimateDepletionDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitialQnt = table.Column<int>(type: "int", nullable: false),
                    TodayUsageQt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMappFertilizers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CMappHerbicides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentQnt = table.Column<int>(type: "int", nullable: false),
                    EstimateDepletionDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitialQnt = table.Column<int>(type: "int", nullable: false),
                    TodayUsageQt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMappHerbicides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CmappMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachementUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasAttachement = table.Column<bool>(type: "bit", nullable: false),
                    IsIncoming = table.Column<bool>(type: "bit", nullable: false),
                    MessageDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageTimeDisplay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderImageUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmappMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CMappSeedlings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentQnt = table.Column<int>(type: "int", nullable: false),
                    EstimateHarvestDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimateWeedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitialQnt = table.Column<int>(type: "int", nullable: false),
                    PlantingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMappSeedlings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CmappTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTaskRepeated = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Task = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmappTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gateway_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    owner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrackTileValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_received = table.Column<DateTime>(type: "datetime2", nullable: false),
                    timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackTileValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrackTileActuator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackTileDeviceId = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrackTileDeviceId = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valueId = table.Column<int>(type: "int", nullable: true)
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
    }
}
