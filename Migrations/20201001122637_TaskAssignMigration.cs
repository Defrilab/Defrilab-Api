using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaiotBackend.Migrations
{
    public partial class TaskAssignMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CmappTasks",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Employee",
                table: "CmappTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Task",
                table: "CmappTasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CmappTasks");

            migrationBuilder.DropColumn(
                name: "Employee",
                table: "CmappTasks");

            migrationBuilder.DropColumn(
                name: "Task",
                table: "CmappTasks");
        }
    }
}
