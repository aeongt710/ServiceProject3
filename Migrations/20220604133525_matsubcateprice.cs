using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceProject3.Migrations
{
    public partial class matsubcateprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialSubCatePrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: true),
                    MaterialSubCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialSubCatePrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialSubCatePrices_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialSubCatePrices_MaterialSubCategory_MaterialSubCategoryId",
                        column: x => x.MaterialSubCategoryId,
                        principalTable: "MaterialSubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSubCatePrices_MaterialId",
                table: "MaterialSubCatePrices",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSubCatePrices_MaterialSubCategoryId",
                table: "MaterialSubCatePrices",
                column: "MaterialSubCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialSubCatePrices");
        }
    }
}
