using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEscolarAPI.Migrations
{
    /// <inheritdoc />
    public partial class correcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DisciplinaAlunoCursos",
                table: "DisciplinaAlunoCursos");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DisciplinaAlunoCursos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DisciplinaAlunoCursos",
                table: "DisciplinaAlunoCursos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaAlunoCursos_AlunoId",
                table: "DisciplinaAlunoCursos",
                column: "AlunoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DisciplinaAlunoCursos",
                table: "DisciplinaAlunoCursos");

            migrationBuilder.DropIndex(
                name: "IX_DisciplinaAlunoCursos_AlunoId",
                table: "DisciplinaAlunoCursos");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DisciplinaAlunoCursos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DisciplinaAlunoCursos",
                table: "DisciplinaAlunoCursos",
                columns: new[] { "AlunoId", "DisciplinaId", "CursoId" });
        }
    }
}
