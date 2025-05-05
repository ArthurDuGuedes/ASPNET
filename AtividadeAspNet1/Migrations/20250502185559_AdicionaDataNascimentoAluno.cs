using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AtividadeAspNet1.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaDataNascimentoAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    password = table.Column<string>(type: "text", nullable: false),
                    nome_usuario = table.Column<string>(type: "text", nullable: false),
                    ramal = table.Column<int>(type: "integer", nullable: false),
                    especialidade = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "maquina",
                columns: table => new
                {
                    id_maquina = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo = table.Column<string>(type: "text", nullable: false),
                    velocidade = table.Column<int>(type: "integer", nullable: false),
                    harddisk = table.Column<int>(type: "integer", nullable: false),
                    placa_rede = table.Column<int>(type: "integer", nullable: false),
                    memoria_ram = table.Column<int>(type: "integer", nullable: false),
                    fk_usuario = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maquina", x => x.id_maquina);
                    table.ForeignKey(
                        name: "FK_maquina_usuarios_fk_usuario",
                        column: x => x.fk_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "software",
                columns: table => new
                {
                    id_software = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    produto = table.Column<string>(type: "text", nullable: false),
                    harddisk = table.Column<int>(type: "integer", nullable: false),
                    memoria_ram = table.Column<int>(type: "integer", nullable: false),
                    fk_maquina = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_software", x => x.id_software);
                    table.ForeignKey(
                        name: "FK_software_maquina_fk_maquina",
                        column: x => x.fk_maquina,
                        principalTable: "maquina",
                        principalColumn: "id_maquina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_maquina_fk_usuario",
                table: "maquina",
                column: "fk_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_software_fk_maquina",
                table: "software",
                column: "fk_maquina");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "software");

            migrationBuilder.DropTable(
                name: "maquina");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
