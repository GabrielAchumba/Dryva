using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dryva.Enrollment.Migrations
{
    public partial class Mirabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaptureSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Photograph = table.Column<byte[]>(nullable: true),
                    RightThumbMinutia = table.Column<byte[]>(nullable: true),
                    RightThumbImage = table.Column<byte[]>(nullable: true),
                    RightIndexMinutia = table.Column<byte[]>(nullable: true),
                    RightIndexImage = table.Column<byte[]>(nullable: true),
                    LeftThumbMinutia = table.Column<byte[]>(nullable: true),
                    LeftThumbImage = table.Column<byte[]>(nullable: true),
                    LeftIndexMinutia = table.Column<byte[]>(nullable: true),
                    LeftIndexImage = table.Column<byte[]>(nullable: true),
                    Signature = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaptureSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 10, nullable: true),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    OtherName = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<string>(maxLength: 8, nullable: true),
                    Csn = table.Column<long>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    ResidentialCity = table.Column<string>(maxLength: 50, nullable: true),
                    ResidentialState = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 80, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 30, nullable: true),
                    BloodGroup = table.Column<string>(maxLength: 10, nullable: true),
                    Genotype = table.Column<string>(maxLength: 10, nullable: true),
                    MaritalStatus = table.Column<string>(maxLength: 10, nullable: true),
                    LGAOfOrigin = table.Column<string>(maxLength: 50, nullable: true),
                    StateOfOrigin = table.Column<string>(maxLength: 50, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    LeftThumbImage = table.Column<byte[]>(nullable: true),
                    LeftIndexImage = table.Column<byte[]>(nullable: true),
                    LeftThumbMinutia = table.Column<byte[]>(nullable: true),
                    LeftIndexMinutia = table.Column<byte[]>(nullable: true),
                    RightThumbImage = table.Column<byte[]>(nullable: true),
                    RightIndexImage = table.Column<byte[]>(nullable: true),
                    RightThumbMinutia = table.Column<byte[]>(nullable: true),
                    RightIndexMinutia = table.Column<byte[]>(nullable: true),
                    Photograph = table.Column<byte[]>(nullable: true),
                    Signature = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    MakeAndModel = table.Column<string>(maxLength: 50, nullable: true),
                    ChassisNumber = table.Column<string>(maxLength: 50, nullable: true),
                    EngineNumber = table.Column<string>(maxLength: 50, nullable: true),
                    PlateNumber = table.Column<string>(maxLength: 50, nullable: true),
                    IsOwner = table.Column<bool>(nullable: false),
                    OwnerSurname = table.Column<string>(maxLength: 50, nullable: true),
                    OwnerFirstName = table.Column<string>(maxLength: 50, nullable: true),
                    OwnerAddress = table.Column<string>(maxLength: 255, nullable: true),
                    OwnerEmail = table.Column<string>(maxLength: 80, nullable: true),
                    OwnerPhoneNumber = table.Column<string>(maxLength: 30, nullable: true),
                    NOKNames = table.Column<string>(maxLength: 80, nullable: true),
                    NOKAddress = table.Column<string>(maxLength: 255, nullable: true),
                    NOKPhoneNumber = table.Column<string>(maxLength: 30, nullable: true),
                    NOKRelationship = table.Column<string>(maxLength: 40, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 20, nullable: true),
                    AccountType = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 10, nullable: true),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    OtherName = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<string>(maxLength: 8, nullable: true),
                    Csn = table.Column<long>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    ResidentialCity = table.Column<string>(maxLength: 50, nullable: true),
                    ResidentialState = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 80, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 30, nullable: true),
                    BloodGroup = table.Column<string>(maxLength: 10, nullable: true),
                    Genotype = table.Column<string>(maxLength: 10, nullable: true),
                    MaritalStatus = table.Column<string>(maxLength: 10, nullable: true),
                    LGAOfOrigin = table.Column<string>(maxLength: 50, nullable: true),
                    StateOfOrigin = table.Column<string>(maxLength: 50, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    LeftThumbImage = table.Column<byte[]>(nullable: true),
                    LeftIndexImage = table.Column<byte[]>(nullable: true),
                    LeftThumbMinutia = table.Column<byte[]>(nullable: true),
                    LeftIndexMinutia = table.Column<byte[]>(nullable: true),
                    RightThumbImage = table.Column<byte[]>(nullable: true),
                    RightIndexImage = table.Column<byte[]>(nullable: true),
                    RightThumbMinutia = table.Column<byte[]>(nullable: true),
                    RightIndexMinutia = table.Column<byte[]>(nullable: true),
                    Photograph = table.Column<byte[]>(nullable: true),
                    Signature = table.Column<byte[]>(nullable: true),
                    PdfDocuments = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lgas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StateId = table.Column<Guid>(nullable: false),
                    StateName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lgas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RTPs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Pin = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 10, nullable: true),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    OtherName = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<string>(maxLength: 8, nullable: true),
                    Csn = table.Column<long>(nullable: true),
                    Percentage = table.Column<decimal>(nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RTPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shareholders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Pin = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 10, nullable: true),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    OtherName = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<string>(maxLength: 8, nullable: true),
                    Csn = table.Column<long>(nullable: true),
                    Percentage = table.Column<decimal>(nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shareholders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaptureSessions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Lgas");

            migrationBuilder.DropTable(
                name: "RTPs");

            migrationBuilder.DropTable(
                name: "Shareholders");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
