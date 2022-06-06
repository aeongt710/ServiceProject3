using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceProject3.Migrations
{
    public partial class nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_MaterialCategory_MaterialCategoryId",
                table: "Material");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSubCategory_MaterialCategory_MaterialCategoryId",
                table: "MaterialSubCategory");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialCategoryId",
                table: "MaterialSubCategory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialCategoryId",
                table: "Material",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_MaterialCategory_MaterialCategoryId",
                table: "Material",
                column: "MaterialCategoryId",
                principalTable: "MaterialCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetDefault);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSubCategory_MaterialCategory_MaterialCategoryId",
                table: "MaterialSubCategory",
                column: "MaterialCategoryId",
                principalTable: "MaterialCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetDefault);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_MaterialCategory_MaterialCategoryId",
                table: "Material");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSubCategory_MaterialCategory_MaterialCategoryId",
                table: "MaterialSubCategory");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialCategoryId",
                table: "MaterialSubCategory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialCategoryId",
                table: "Material",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Material_MaterialCategory_MaterialCategoryId",
                table: "Material",
                column: "MaterialCategoryId",
                principalTable: "MaterialCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSubCategory_MaterialCategory_MaterialCategoryId",
                table: "MaterialSubCategory",
                column: "MaterialCategoryId",
                principalTable: "MaterialCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
