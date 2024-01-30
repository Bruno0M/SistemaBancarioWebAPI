using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaBancarioWebAPI.Migrations
{
    public partial class AjusteFK2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_his_transacao_CartaoId",
                table: "his_transacao");

            migrationBuilder.CreateIndex(
                name: "IX_his_transacao_CartaoId",
                table: "his_transacao",
                column: "CartaoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_his_transacao_CartaoId",
                table: "his_transacao");

            migrationBuilder.CreateIndex(
                name: "IX_his_transacao_CartaoId",
                table: "his_transacao",
                column: "CartaoId");
        }
    }
}
