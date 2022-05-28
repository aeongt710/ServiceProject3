using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceProject3.Migrations
{
    public partial class matsubcateadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialSubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialSubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialSubCategory_MaterialCategory_MaterialCategoryId",
                        column: x => x.MaterialCategoryId,
                        principalTable: "MaterialCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSubCategory_MaterialCategoryId",
                table: "MaterialSubCategory",
                column: "MaterialCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialSubCategory");
        }
    }
}
