using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceProject3.Migrations
{
    public partial class materialBoughtModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubCategory",
                table: "MaterialBought",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubCategory",
                table: "MaterialBought");
        }
    }
}
