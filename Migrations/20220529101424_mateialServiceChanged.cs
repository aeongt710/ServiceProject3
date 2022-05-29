using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceProject3.Migrations
{
    public partial class mateialServiceChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "MaterialBought",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "MaterialBought",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "MaterialBought",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPrice",
                table: "MaterialBought",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "MaterialBought");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "MaterialBought");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "MaterialBought");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "MaterialBought",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
