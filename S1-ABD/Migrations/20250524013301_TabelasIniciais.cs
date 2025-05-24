using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S1_ABD.Migrations
{
    /// <inheritdoc />
    public partial class TabelasIniciais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_MOTOS",
                columns: table => new
                {
                    id_moto = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    marca = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    modelo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ano = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    placa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    em_uso = table.Column<int>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MOTOS", x => x.id_moto);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USUARIOS",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_usuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_USUARIOS", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "TBL_REGISTROS",
                columns: table => new
                {
                    id_registro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    id_moto = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    dt_retirada = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    dt_devolucao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_REGISTROS", x => x.id_registro);
                    table.ForeignKey(
                        name: "FK_TBL_REGISTROS_TBL_MOTOS_id_moto",
                        column: x => x.id_moto,
                        principalTable: "TBL_MOTOS",
                        principalColumn: "id_moto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_REGISTROS_TBL_USUARIOS_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "TBL_USUARIOS",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_REGISTROS_id_moto",
                table: "TBL_REGISTROS",
                column: "id_moto");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_REGISTROS_id_usuario",
                table: "TBL_REGISTROS",
                column: "id_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_REGISTROS");

            migrationBuilder.DropTable(
                name: "TBL_MOTOS");

            migrationBuilder.DropTable(
                name: "TBL_USUARIOS");
        }
    }
}
