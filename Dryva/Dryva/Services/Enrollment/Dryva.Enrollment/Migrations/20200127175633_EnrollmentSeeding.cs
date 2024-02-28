using Microsoft.EntityFrameworkCore.Migrations;

namespace Dryva.Enrollment.Migrations
{
    public partial class EnrollmentSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Pin",
                table: "Shareholders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Pin",
                table: "RTPs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Pin",
                table: "Shareholders",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "Pin",
                table: "RTPs",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
