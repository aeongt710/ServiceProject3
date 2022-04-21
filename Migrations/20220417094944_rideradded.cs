using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceProject3.Migrations
{
    public partial class rideradded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RiderId",
                table: "MaterialBought",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialBought_RiderId",
                table: "MaterialBought",
                column: "RiderId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialBought_AspNetUsers_RiderId",
                table: "MaterialBought",
                column: "RiderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialBought_AspNetUsers_RiderId",
                table: "MaterialBought");

            migrationBuilder.DropIndex(
                name: "IX_MaterialBought_RiderId",
                table: "MaterialBought");

            migrationBuilder.DropColumn(
                name: "RiderId",
                table: "MaterialBought");
        }
    }
}
