using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaBancarioWebAPI.Migrations
{
    public partial class CriandoBdETabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_cartoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero_cartao = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    cvv = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    data_validade = table.Column<DateTime>(type: "date", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cartoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_cartoes_tb_pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "tb_pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_conta_corrente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero_conta = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    CartaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_conta_corrente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_conta_corrente_tb_cartoes_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "tb_cartoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_saldo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    saldo_conta = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    ContaCorrenteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_saldo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_saldo_tb_conta_corrente_ContaCorrenteId",
                        column: x => x.ContaCorrenteId,
                        principalTable: "tb_conta_corrente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_cartoes_PessoaId",
                table: "tb_cartoes",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_conta_corrente_CartaoId",
                table: "tb_conta_corrente",
                column: "CartaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_saldo_ContaCorrenteId",
                table: "tb_saldo",
                column: "ContaCorrenteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_saldo");

            migrationBuilder.DropTable(
                name: "tb_conta_corrente");

            migrationBuilder.DropTable(
                name: "tb_cartoes");

            migrationBuilder.DropTable(
                name: "tb_pessoas");
        }
    }
}
