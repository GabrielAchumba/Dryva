using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dryva.Financials.CustomerService.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    SubscriptionId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    ModifiedOn = table.Column<DateTimeOffset>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DepleteAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TransactionCode = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: false),
                    RechargeCode = table.Column<long>(nullable: false),

                    CustomerId = table.Column<Guid>(nullable: false),
                    CardSerialNumber = table.Column<long>(nullable: false),

                    VendorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.SubscriptionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}
