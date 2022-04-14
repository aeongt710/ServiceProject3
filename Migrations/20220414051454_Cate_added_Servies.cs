using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceProject3.Migrations
{
    public partial class Cate_added_Servies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Service",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Service_CategoryId",
                table: "Service",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Category_CategoryId",
                table: "Service",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Category_CategoryId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_CategoryId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Service");
        }
    }
}
