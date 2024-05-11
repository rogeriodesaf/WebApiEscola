using Microsoft.EntityFrameworkCore.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIEscola.Migrations
{
    /// <inheritdoc />
    public partial class novaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessoresModelId",
                table: "Disciplina",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Professor_ProfessoresModelId",
                table: "Disciplina");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropIndex(
                name: "IX_Disciplina_ProfessoresModelId",
                table: "Disciplina");

            migrationBuilder.DropColumn(
                name: "ProfessoresModelId",
                table: "Disciplina");
        }
    }
}
