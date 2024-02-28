using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dryva.Devices.Migrations
{
    public partial class device1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    SerialNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Terminal = table.Column<int>(nullable: false),
                    Class = table.Column<string>(maxLength: 20, nullable: true),
                    Activated = table.Column<bool>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    EW = table.Column<string>(nullable: false),
                    NS = table.Column<string>(nullable: false),
                    Speed = table.Column<float>(nullable: true),
                    Course = table.Column<float>(nullable: true),
                    GpsModifiedOn = table.Column<DateTime>(nullable: true),
                    MapAxisId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceTrails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Terminal = table.Column<int>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    EW = table.Column<string>(nullable: false),
                    NS = table.Column<string>(nullable: false),
                    Speed = table.Column<float>(nullable: true),
                    Course = table.Column<float>(nullable: true),
                    GpsModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTrails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntryTransitLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    LogId = table.Column<long>(nullable: false),
                    RechargeCode = table.Column<int>(nullable: false),
                    UnitsLeft = table.Column<int>(nullable: false),
                    Csn = table.Column<long>(nullable: false),
                    Terminal = table.Column<int>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    EW = table.Column<string>(nullable: false),
                    NS = table.Column<string>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryTransitLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExitTransitLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    LogId = table.Column<long>(nullable: false),
                    RechargeCode = table.Column<int>(nullable: false),
                    UnitsLeft = table.Column<int>(nullable: false),
                    Csn = table.Column<long>(nullable: false),
                    Terminal = table.Column<int>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    LongEW = table.Column<string>(nullable: false),
                    LatNS = table.Column<string>(nullable: false),
                    Time = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExitTransitLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_SerialNumber",
                table: "Devices",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_Terminal",
                table: "Devices",
                column: "Terminal",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "DeviceTrails");

            migrationBuilder.DropTable(
                name: "EntryTransitLogs");

            migrationBuilder.DropTable(
                name: "ExitTransitLogs");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
