using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaBancarioWebAPI.Migrations
{
    public partial class AjusteFK3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_his_transacao_tb_cartoes_CartaoId",
                table: "his_transacao");

            migrationBuilder.RenameColumn(
                name: "CartaoId",
                table: "his_transacao",
                newName: "ContaCorrenteId");

            migrationBuilder.RenameIndex(
                name: "IX_his_transacao_CartaoId",
                table: "his_transacao",
                newName: "IX_his_transacao_ContaCorrenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_his_transacao_tb_conta_corrente_ContaCorrenteId",
                table: "his_transacao",
                column: "ContaCorrenteId",
                principalTable: "tb_conta_corrente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_his_transacao_tb_conta_corrente_ContaCorrenteId",
                table: "his_transacao");

            migrationBuilder.RenameColumn(
                name: "ContaCorrenteId",
                table: "his_transacao",
                newName: "CartaoId");

            migrationBuilder.RenameIndex(
                name: "IX_his_transacao_ContaCorrenteId",
                table: "his_transacao",
                newName: "IX_his_transacao_CartaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_his_transacao_tb_cartoes_CartaoId",
                table: "his_transacao",
                column: "CartaoId",
                principalTable: "tb_cartoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
