using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourLocalization.Infrastructure.Migrations
{
    public partial class AddNewPropertTypeToPointModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Points",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Points");
        }
    }
}