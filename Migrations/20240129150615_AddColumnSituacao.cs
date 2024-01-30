using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaBancarioWebAPI.Migrations
{
    public partial class AddColumnSituacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "situacao",
                table: "his_transacao",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "situacao",
                table: "his_transacao");
        }
    }
}
