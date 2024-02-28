using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dryva.VendorSubscription.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerSubscription",
                columns: table => new
                {
                    SubscriptionId = table.Column<Guid>(nullable: false),
                    VendorId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    CardSerialNumber = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSubscription", x => x.SubscriptionId);
                });

            migrationBuilder.CreateTable(
                name: "VendorSubscription",
                columns: table => new
                {
                    SubscriptionId = table.Column<Guid>(nullable: false),
                    VendorId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    ModifiedOn = table.Column<DateTimeOffset>(nullable: false),
                    RechargeCode = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
                    DepleteAmount = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
                    TransactionCode = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorSubscription", x => x.SubscriptionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerSubscription");

            migrationBuilder.DropTable(
                name: "VendorSubscription");
        }
    }
}
