using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIEscola.Migrations
{
    /// <inheritdoc />
    public partial class NovaMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Professor_ProfessoresModelId",
                table: "Disciplina");

            migrationBuilder.DropIndex(
                name: "IX_Disciplina_ProfessoresModelId",
                table: "Disciplina");

            migrationBuilder.DropColumn(
                name: "ProfessoresModelId",
                table: "Disciplina");

            migrationBuilder.AddColumn<int>(
                name: "ProfessoresId",
                table: "Disciplina",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_ProfessoresId",
                table: "Disciplina",
                column: "ProfessoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Professor_ProfessoresId",
                table: "Disciplina",
                column: "ProfessoresId",
                principalTable: "Professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Professor_ProfessoresId",
                table: "Disciplina");

            migrationBuilder.DropIndex(
                name: "IX_Disciplina_ProfessoresId",
                table: "Disciplina");

            migrationBuilder.DropColumn(
                name: "ProfessoresId",
                table: "Disciplina");

            migrationBuilder.AddColumn<int>(
                name: "ProfessoresModelId",
                table: "Disciplina",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_ProfessoresModelId",
                table: "Disciplina",
                column: "ProfessoresModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Professor_ProfessoresModelId",
                table: "Disciplina",
                column: "ProfessoresModelId",
                principalTable: "Professor",
                principalColumn: "Id");
        }
    }
}
