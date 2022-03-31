using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceProject3.Migrations
{
    public partial class startingproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Note",
                table: "MaterialBought",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "CompletionStatus",
                table: "MaterialBought",
                newName: "DeliveryStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeliveryStatus",
                table: "MaterialBought",
                newName: "CompletionStatus");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "MaterialBought",
                newName: "Note");
        }
    }
}
