using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourLocalization.Infrastructure.Migrations
{
    public partial class AddTypeIdPropertyToSubtypeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subtypes_Types_TypeId",
                table: "Subtypes");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Subtypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subtypes_Types_TypeId",
                table: "Subtypes",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subtypes_Types_TypeId",
                table: "Subtypes");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Subtypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Subtypes_Types_TypeId",
                table: "Subtypes",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id");
        }
    }
}
