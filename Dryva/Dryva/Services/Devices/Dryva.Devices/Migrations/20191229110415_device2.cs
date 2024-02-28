using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dryva.Devices.Migrations
{
    public partial class device2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Devices",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RouteId",
                table: "Devices",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Devices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Devices");
        }
    }
}
