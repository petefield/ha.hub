using Microsoft.EntityFrameworkCore.Migrations;

namespace ha.data.Migrations
{
    public partial class RenameSettingsToCommands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SettingName",
                table: "DeviceStates");

            migrationBuilder.DropColumn(
                name: "SettingValue",
                table: "DeviceStates");

            migrationBuilder.AddColumn<string>(
                name: "CommandName",
                table: "DeviceStates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExecutionOrder",
                table: "DeviceStates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Parameters",
                table: "DeviceStates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommandName",
                table: "DeviceStates");

            migrationBuilder.DropColumn(
                name: "ExecutionOrder",
                table: "DeviceStates");

            migrationBuilder.DropColumn(
                name: "Parameters",
                table: "DeviceStates");

            migrationBuilder.AddColumn<string>(
                name: "SettingName",
                table: "DeviceStates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SettingValue",
                table: "DeviceStates",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
