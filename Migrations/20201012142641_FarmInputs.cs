using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaiotBackend.Migrations
{
    public partial class FarmInputs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leaders");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.CreateTable(
                name: "CMappFertilizers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InitialQnt = table.Column<int>(nullable: false),
                    CurrentQnt = table.Column<int>(nullable: false),
                    TodayUsageQt = table.Column<int>(nullable: false),
                    EstimateDepletionDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMappFertilizers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CMappHerbicides",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InitialQnt = table.Column<int>(nullable: false),
                    CurrentQnt = table.Column<int>(nullable: false),
                    TodayUsageQt = table.Column<int>(nullable: false),
                    EstimateDepletionDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMappHerbicides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CmappMessages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachementUrl = table.Column<string>(nullable: true),
                    IsIncoming = table.Column<bool>(nullable: false),
                    MessageDateTime = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    MessageTimeDisplay = table.Column<string>(nullable: true),
                    HasAttachement = table.Column<bool>(nullable: false),
                    SenderImageUri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmappMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CMappSeedlings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Species = table.Column<string>(nullable: true),
                    InitialQnt = table.Column<int>(nullable: false),
                    CurrentQnt = table.Column<int>(nullable: false),
                    PlantingDate = table.Column<string>(nullable: true),
                    EstimateWeedDate = table.Column<string>(nullable: true),
                    EstimateHarvestDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMappSeedlings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CMappFertilizers");

            migrationBuilder.DropTable(
                name: "CMappHerbicides");

            migrationBuilder.DropTable(
                name: "CmappMessages");

            migrationBuilder.DropTable(
                name: "CMappSeedlings");

            migrationBuilder.CreateTable(
                name: "Leaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstDateInOffice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PopularName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Leader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sponsor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSpan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });
        }
    }
}
