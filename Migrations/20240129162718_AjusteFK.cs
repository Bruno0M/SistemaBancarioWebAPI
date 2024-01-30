using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaBancarioWebAPI.Migrations
{
    public partial class AjusteFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_his_transacao_tb_conta_corrente_ContaCorrenteModelId",
                table: "his_transacao");

            migrationBuilder.DropIndex(
                name: "IX_his_transacao_ContaCorrenteModelId",
                table: "his_transacao");

            migrationBuilder.DropColumn(
                name: "ContaCorrenteModelId",
                table: "his_transacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContaCorrenteModelId",
                table: "his_transacao",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_his_transacao_ContaCorrenteModelId",
                table: "his_transacao",
                column: "ContaCorrenteModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_his_transacao_tb_conta_corrente_ContaCorrenteModelId",
                table: "his_transacao",
                column: "ContaCorrenteModelId",
                principalTable: "tb_conta_corrente",
                principalColumn: "Id");
        }
    }
}
