using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaBancarioWebAPI.Migrations
{
    public partial class removeFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_his_transacao_tb_conta_corrente_ContaCorrenteId",
                table: "his_transacao");

            migrationBuilder.DropIndex(
                name: "IX_his_transacao_ContaCorrenteId",
                table: "his_transacao");

            migrationBuilder.DropColumn(
                name: "ContaCorrenteId",
                table: "his_transacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContaCorrenteId",
                table: "his_transacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_his_transacao_ContaCorrenteId",
                table: "his_transacao",
                column: "ContaCorrenteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_his_transacao_tb_conta_corrente_ContaCorrenteId",
                table: "his_transacao",
                column: "ContaCorrenteId",
                principalTable: "tb_conta_corrente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
