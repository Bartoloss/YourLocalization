using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourLocalization.Infrastructure.Migrations
{
    public partial class AddAllPointsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuildingNumber",
                table: "Points",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Points",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Points",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Points",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Points",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingNumber",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Points");
        }
    }
}