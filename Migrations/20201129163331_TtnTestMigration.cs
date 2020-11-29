using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaiotBackend.Migrations
{
    public partial class TtnTestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gateways",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gtw_id = table.Column<string>(nullable: true),
                    timestamp = table.Column<int>(nullable: false),
                    time = table.Column<string>(nullable: true),
                    channel = table.Column<int>(nullable: false),
                    rssi = table.Column<int>(nullable: false),
                    snr = table.Column<int>(nullable: false),
                    rf_chain = table.Column<int>(nullable: false),
                    latitude = table.Column<double>(nullable: false),
                    longitude = table.Column<double>(nullable: false),
                    altitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gateways", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "payload_fields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payload_fields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "metadata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    time = table.Column<string>(nullable: true),
                    frequency = table.Column<double>(nullable: false),
                    modulation = table.Column<string>(nullable: true),
                    data_rate = table.Column<string>(nullable: true),
                    bit_rate = table.Column<int>(nullable: false),
                    coding_rate = table.Column<string>(nullable: true),
                    gatewaysId = table.Column<int>(nullable: true),
                    latitude = table.Column<double>(nullable: false),
                    longitude = table.Column<double>(nullable: false),
                    altitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_metadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_metadata_gateways_gatewaysId",
                        column: x => x.gatewaysId,
                        principalTable: "gateways",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TttnTestData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    app_id = table.Column<string>(nullable: true),
                    dev_id = table.Column<string>(nullable: true),
                    hardware_serial = table.Column<string>(nullable: true),
                    port = table.Column<int>(nullable: false),
                    counter = table.Column<int>(nullable: false),
                    is_retry = table.Column<bool>(nullable: false),
                    confirmed = table.Column<bool>(nullable: false),
                    payload_raw = table.Column<string>(nullable: true),
                    payload_fieldsId = table.Column<int>(nullable: true),
                    metadataId = table.Column<int>(nullable: true),
                    downlink_url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TttnTestData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TttnTestData_metadata_metadataId",
                        column: x => x.metadataId,
                        principalTable: "metadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TttnTestData_payload_fields_payload_fieldsId",
                        column: x => x.payload_fieldsId,
                        principalTable: "payload_fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_metadata_gatewaysId",
                table: "metadata",
                column: "gatewaysId");

            migrationBuilder.CreateIndex(
                name: "IX_TttnTestData_metadataId",
                table: "TttnTestData",
                column: "metadataId");

            migrationBuilder.CreateIndex(
                name: "IX_TttnTestData_payload_fieldsId",
                table: "TttnTestData",
                column: "payload_fieldsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TttnTestData");

            migrationBuilder.DropTable(
                name: "metadata");

            migrationBuilder.DropTable(
                name: "payload_fields");

            migrationBuilder.DropTable(
                name: "gateways");
        }
    }
}
