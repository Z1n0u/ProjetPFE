using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetPFE.Server.Migrations
{
    /// <inheritdoc />
    public partial class MakeSousCategorieNonNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Risques_Sous_Categories_Sous_CategorieLabel_Sous_Categorie",
                table: "Risques");

            migrationBuilder.AlterColumn<string>(
                name: "Sous_CategorieLabel_Sous_Categorie",
                table: "Risques",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Risques_Sous_Categories_Sous_CategorieLabel_Sous_Categorie",
                table: "Risques",
                column: "Sous_CategorieLabel_Sous_Categorie",
                principalTable: "Sous_Categories",
                principalColumn: "Label_Sous_Categorie",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Risques_Sous_Categories_Sous_CategorieLabel_Sous_Categorie",
                table: "Risques");

            migrationBuilder.AlterColumn<string>(
                name: "Sous_CategorieLabel_Sous_Categorie",
                table: "Risques",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Risques_Sous_Categories_Sous_CategorieLabel_Sous_Categorie",
                table: "Risques",
                column: "Sous_CategorieLabel_Sous_Categorie",
                principalTable: "Sous_Categories",
                principalColumn: "Label_Sous_Categorie");
        }
    }
}
