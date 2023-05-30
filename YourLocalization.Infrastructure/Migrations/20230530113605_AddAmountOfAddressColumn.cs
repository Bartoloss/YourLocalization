using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourLocalization.Infrastructure.Migrations
{
    public partial class AddAmountOfAddressColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountOfAddresses",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfAddresses",
                table: "AspNetUsers");
        }
    }
}
