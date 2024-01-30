using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaBancarioWebAPI.Migrations
{
    public partial class AddTransacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "his_transacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor_compra = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    data_compra = table.Column<DateTime>(type: "date", nullable: false),
                    forma_pagamento = table.Column<int>(type: "int", nullable: false),
                    Situacao = table.Column<bool>(type: "bit", nullable: false),
                    CartaoId = table.Column<int>(type: "int", nullable: false),
                    ContaCorrenteModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_his_transacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_his_transacao_tb_cartoes_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "tb_cartoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_his_transacao_tb_conta_corrente_ContaCorrenteModelId",
                        column: x => x.ContaCorrenteModelId,
                        principalTable: "tb_conta_corrente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_his_transacao_CartaoId",
                table: "his_transacao",
                column: "CartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_his_transacao_ContaCorrenteModelId",
                table: "his_transacao",
                column: "ContaCorrenteModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "his_transacao");
        }
    }
}
