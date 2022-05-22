using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceProject3.Migrations
{
    public partial class MaterialCategoryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaterialCategoryId",
                table: "Material",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MaterialCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Material_MaterialCategoryId",
                table: "Material",
                column: "MaterialCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_MaterialCategory_MaterialCategoryId",
                table: "Material",
                column: "MaterialCategoryId",
                principalTable: "MaterialCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_MaterialCategory_MaterialCategoryId",
                table: "Material");

            migrationBuilder.DropTable(
                name: "MaterialCategory");

            migrationBuilder.DropIndex(
                name: "IX_Material_MaterialCategoryId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "MaterialCategoryId",
                table: "Material");
        }
    }
}
