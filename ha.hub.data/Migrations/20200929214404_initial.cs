using Microsoft.EntityFrameworkCore.Migrations;

namespace ha.data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DeviceType = table.Column<string>(nullable: true),
                    Config = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scenes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceStates",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DeviceId = table.Column<string>(nullable: true),
                    SettingName = table.Column<string>(nullable: true),
                    SettingValue = table.Column<string>(nullable: true),
                    DbSceneId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceStates_Scenes_DbSceneId",
                        column: x => x.DbSceneId,
                        principalTable: "Scenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeviceStates_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceStates_DbSceneId",
                table: "DeviceStates",
                column: "DbSceneId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceStates_DeviceId",
                table: "DeviceStates",
                column: "DeviceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceStates");

            migrationBuilder.DropTable(
                name: "Scenes");

            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
